using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
namespace Model.Repositories
{
    public class EFCoreMappingContext : DbContext
    {
        public static IConfigurationRoot configuration;
        bool testMode = false;

        // Complex Type 
        public DbSet<Campus> Campussen { get; set; }
        public DbSet<Docent> Docenten { get; set; }
        // Inheritance: TPH 
        public DbSet<TPHCursus> TPHCursussen { get; set; }
        public DbSet<TPHKlassikaleCursus> TPHKlassikaleCursussen { get; set; }
        public DbSet<TPHZelfstudieCursus> TPHZelfstudieCursussen { get; set; }

        // Associaties 
        public DbSet<ASSDocent> ASSDocenten { get; set; }
        public DbSet<ASSCampus> ASSCampussen { get; set; }

        // Assiociatie veel-op-veel 
        public DbSet<ASSBoek> AssBoeken { get; set; }
        public DbSet<ASSCursus> AssCursussen { get; set; }
        public DbSet<ASSBoekCursus> AssBoekenCursussen { get; set; }

        // ------------ 
        // Constructors 
        // ------------ 
        public EFCoreMappingContext()
        {
        }

        public EFCoreMappingContext(DbContextOptions<EFCoreMappingContext> options) : base(options)
        {
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information));
            return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Zoek de naam in de connectionStrings section - appsettings.json 
                configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                // .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", false)
                .Build();

                var connectionString = configuration.GetConnectionString("efcoremapping");
                if (connectionString != null)

                // Indien de naam is gevonden 
                {
                    optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(150)) // Max aantal SQL commands die kunnen doorgestuurd worden naar de database 
                        .UseLoggerFactory(GetLoggerFactory())
                        .EnableSensitiveDataLogging(true)       // Toont de waarden van de parameters bij de logging 
                        .UseLazyLoadingProxies();
                }
            }
            else
            {
                testMode = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ------------------------ 
            // Veel-op-Veel Associaties 
            // ------------------------ 
            modelBuilder.Entity<Model.Entities.ASSBoek>().ToTable("ASSBoeken");
            modelBuilder.Entity<Model.Entities.ASSCursus>().ToTable("ASSCursussen");
            modelBuilder.Entity<Model.Entities.ASSBoekCursus>().ToTable("ASSBoekenCursussen");
            modelBuilder.Entity<ASSBoek>().HasKey(c => c.BoekId);
            modelBuilder.Entity<ASSCursus>().HasKey(c => c.CursusId);
            modelBuilder.Entity<ASSBoekCursus>().HasKey(c => new { c.BoekId, c.CursusId });
            modelBuilder.Entity<ASSCursus>().Property(b => b.Naam)
                                            .IsRequired()
                                            .HasMaxLength(50);
            modelBuilder.Entity<ASSBoek>().Property(b => b.Titel)
                                          .HasMaxLength(150);
            modelBuilder.Entity<ASSBoek>().Property(b => b.IsbnNr)
                                          .IsRequired()
                                          .HasMaxLength(13);
            modelBuilder.Entity<ASSBoek>(entity => { entity.HasIndex(e => e.IsbnNr).IsUnique(); });
            modelBuilder.Entity<ASSBoekCursus>() // (1) 
                    .HasOne(x => x.Boek) // (2) 
                    .WithMany(y => y.BoekenCursussen) // (3) 
                    .HasForeignKey(x => x.BoekId); // (4) 
            modelBuilder.Entity<ASSBoekCursus>()
                .HasOne(x => x.Cursus)
                .WithMany(y => y.BoekenCursussen)
                .HasForeignKey(x => x.CursusId);

            // ----------- 
            // Associaties 
            // ----------- 
            modelBuilder.Entity<ASSCampus>().OwnsOne(s => s.Adres);
            modelBuilder.Entity<ASSCampus>().OwnsOne(s => s.Adres).Property(b => b.Straat).HasColumnName("Straat");
            modelBuilder.Entity<ASSCampus>().OwnsOne(s => s.Adres).Property(b => b.Huisnummer).HasColumnName("HuisNr");
            modelBuilder.Entity<ASSCampus>().OwnsOne(s => s.Adres).Property(b => b.Postcode).HasColumnName("PostCd");
            modelBuilder.Entity<ASSCampus>().OwnsOne(s => s.Adres).Property(b => b.Gemeente).HasColumnName("Gemeente");
            modelBuilder.Entity<ASSDocent>().OwnsOne(s => s.Adres);
            modelBuilder.Entity<ASSDocent>().OwnsOne(s => s.Adres).Property(b => b.Gemeente).HasColumnName("Gemeente");
            modelBuilder.Entity<ASSDocent>().OwnsOne(s => s.Adres).Property(b => b.Huisnummer).HasColumnName("HuisNr");
            modelBuilder.Entity<ASSDocent>().OwnsOne(s => s.Adres).Property(b => b.Postcode).HasColumnName("PostCd");
            modelBuilder.Entity<ASSDocent>().OwnsOne(s => s.Adres).Property(b => b.Straat).HasColumnName("Straat");

            //modelBuilder.Entity<ASSDocent>() 
            // .HasOne(b => b.ASSCampus) 
            // .WithMany(c => c.ASSDocenten) 
            // .HasForeignKey(b => b.CampusId);

            // ---------------- 
            // Inheritance: TPH 
            // ---------------- 

            modelBuilder.Entity<TPHCursus>().ToTable("TPHCursussen") // (1) 
                .HasDiscriminator<string>("CursusType") // (2) 
                .HasValue<TPHKlassikaleCursus>("K") // (3) 
                .HasValue<TPHZelfstudieCursus>("Z");

            // ------ 
            // Docent 
            // ------ 
            modelBuilder.Entity<Model.Entities.Docent>().ToTable("Docenten");
            modelBuilder.Entity<Docent>().HasKey(c => c.DocentId);
            modelBuilder.Entity<Docent>().Property(b => b.DocentId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Docent>().Property(b => b.Voornaam)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Docent>().Property(b => b.Familienaam)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Docent>().Property(b => b.Wedde)
                .HasColumnName("Maandwedde")
                .HasColumnType("decimal(18, 4)");
            modelBuilder.Entity<Docent>().Property(b => b.InDienst)
                .HasColumnType("date");
            modelBuilder.Entity<Docent>()
                .HasOne(b => b.Campus)
                .WithMany(c => c.Docenten)
                .HasForeignKey(b => b.CampusId);

            // ------ 
            // Campus 
            // ------ 
            modelBuilder.Entity<Campus>().ToTable("Campussen");
            modelBuilder.Entity<Campus>().HasKey(c => c.CampusId);
            modelBuilder.Entity<Campus>().Property(b => b.CampusId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Campus>().Property(b => b.Naam)
                .HasColumnName("CampusNaam")
                .IsRequired();
            modelBuilder.Entity<Campus>().Ignore(c => c.Commentaar);

            // ----- 
            // Adres 
            // ----- 
            //modelBuilder.Entity<Campus>().OwnsOne(s => s.Adres).ToTable("CampusAdressen"); 
            //modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresThuis).ToTable("DocentAdressenThuis"); 
            //modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresWerk).ToTable("DocentAdressenWerk");

            // Voor campus 
            modelBuilder.Entity<Campus>().OwnsOne(s => s.Adres);
            modelBuilder.Entity<Campus>().OwnsOne(s => s.Adres).Property(b => b.Straat).HasColumnName("Straat");
            modelBuilder.Entity<Campus>().OwnsOne(s => s.Adres).Property(b => b.Huisnummer).HasColumnName("HuisNr");
            modelBuilder.Entity<Campus>().OwnsOne(s => s.Adres).Property(b => b.Postcode).HasColumnName("PostCd");
            modelBuilder.Entity<Campus>().OwnsOne(s => s.Adres).Property(b => b.Gemeente).HasColumnName("Gemeente");

            // Voor Docent 
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresThuis);
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresThuis).Property(b => b.Gemeente)
                                                                    .HasColumnName("GemeenteThuis");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresThuis).Property(b => b.Huisnummer)
                                                                    .HasColumnName("HuisNrThuis");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresThuis).Property(b => b.Postcode)
                                                                    .HasColumnName("PostCdThuis");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresThuis).Property(b => b.Straat)
                                                                    .HasColumnName("StraatThuis");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresWerk);
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresWerk).Property(b => b.Gemeente)
                                                                   .HasColumnName("GemeenteWerk");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresWerk).Property(b => b.Huisnummer)
                                                                   .HasColumnName("HuisNrWerk");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresWerk).Property(b => b.Postcode)
                                                                   .HasColumnName("PostCdWerk");
            modelBuilder.Entity<Docent>().OwnsOne(s => s.AdresWerk).Property(b => b.Straat)
                                                                   .HasColumnName("StraatWerk");

            if (!testMode)
            {
                // ----------------------------------- 
                // Seeding 
                // Veel-op-Veel Associaties 
                // ----------------------------------- 
                modelBuilder.Entity<ASSBoek>().HasData(new ASSBoek
                {
                    BoekId = 1,
                    IsbnNr = "0-0705918-0-6",
                    Titel = "C++ : For Scientists and Engineers"
                },
                new ASSBoek
                {
                    BoekId = 2,
                    IsbnNr = "0-0788212-3-1",
                    Titel = "C++ : The Complete Reference"
                },
                new ASSBoek
                {
                    BoekId = 3,
                    IsbnNr = "1-5659211-6-X",
                    Titel = "C++ : The Core Language"
                },
                new ASSBoek
                {
                    BoekId = 4,
                    IsbnNr = "0-4448771-8-5",
                    Titel = "Relational Database Systems"
                },
                new ASSBoek
                {
                    BoekId = 5,
                    IsbnNr = "1-5595851-1-0",
                    Titel = "Access from the Ground Up"
                },
                new ASSBoek
                {
                    BoekId = 6,
                    IsbnNr = "0-0788212-2-3",
                    Titel = "Oracle : A Beginner''s Guide"
                },
                new ASSBoek
                {
                    BoekId = 7,
                    IsbnNr = "0-0788209-7-9",
                    Titel = "Oracle : The Complete Reference"
                }
                    );
                modelBuilder.Entity<ASSCursus>().HasData(new ASSCursus
                {
                    CursusId = 1,
                    Naam = "C++"
                },
                new ASSCursus
                {
                    CursusId = 2,
                    Naam = "Access"
                },
                new ASSCursus
                {
                    CursusId = 3,
                    Naam = "Oracle"
                });

            }


        }
    }
}
