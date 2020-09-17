using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

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
        public DbSet<ASSActiviteit> AssActiviteiten { get; set; }
        public DbSet<ASSDocentActiviteit> AssDocentenActiviteiten { get; set; }

        // Associatie naar dezelfde tabel 
        public DbSet<ASSWerknemer> AssWerknemers { get; set; }
        public DbSet<ASSWerknemer1> AssWerknemers1 { get; set; }
        public DbSet<Personeelsleden> Personeelsledens { get; set; }


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

                     

            // ------------------------------ 
            // Associatie naar dezelfde tabel 
            // ------------------------------ 
            
            // Tabellen 
            
            modelBuilder.Entity<Model.Entities.ASSWerknemer1>().ToTable("ASSWerknemers1"); 
            
            // PK's 
            
            modelBuilder.Entity<ASSWerknemer1>().HasKey(c => c.WerknemerId); 
            
            // Properties 
            
            modelBuilder.Entity<ASSWerknemer1>().Property(b => b.Voornaam) 
                        .HasMaxLength(40); 
            modelBuilder.Entity<ASSWerknemer1>().Property(b => b.Familienaam)
                        .IsRequired()
                        .HasMaxLength(50); 
            
            // Associaties 
            
            modelBuilder.Entity<ASSWerknemer1>() 
                        .HasOne(x => x.Overste) 
                        .WithMany(y => y.Werknemers) 
                        .HasForeignKey(x => x.OversteId) 
                        .HasConstraintName("FK_WerknemerOverste");

            // ----------------------- 
            // Docenten & Activiteiten 
            // ----------------------- 
            // Tabellen 

            modelBuilder.Entity<Model.Entities.ASSActiviteit>().ToTable("ASSActiviteiten"); 
            modelBuilder.Entity<Model.Entities.ASSDocentActiviteit>().ToTable("ASSDocentenActiviteiten"); 
            
            // PK's 
            
            modelBuilder.Entity<ASSActiviteit>().HasKey(c => c.ActiviteitId); 
            modelBuilder.Entity<ASSDocentActiviteit>().HasKey(c => new {c.DocentId, c.ActiviteitId }); 
            
            // Properties 
            
            modelBuilder.Entity<ASSActiviteit>().Property(b => b.Naam) .IsRequired() .HasMaxLength(50); 
            
            // FK's 
            modelBuilder.Entity<ASSDocentActiviteit>() 
                        .HasOne(x => x.Docent) 
                        .WithMany(y => y.DocentenActiviteiten) 
                        .HasForeignKey(x => x.DocentId); 
            modelBuilder.Entity<ASSDocentActiviteit>() 
                        .HasOne(x => x.Activiteit) 
                        .WithMany(y => y.DocentenActiviteiten) 
                        .HasForeignKey(x => x.ActiviteitId);

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

                // Seeding ASSWerknemers1 
                var werknemers = new List<ASSWerknemer1>() 
                { 
                    new ASSWerknemer1 { WerknemerId = 01, Voornaam = "Agnes", Familienaam = "Szavay" }, new ASSWerknemer1 { WerknemerId = 02, Voornaam = "Agnieszka", Familienaam = "Radwanska" }, new ASSWerknemer1 { WerknemerId = 03, Voornaam = "Agustin", Familienaam = "Calleri" }, new ASSWerknemer1 { WerknemerId = 04, Voornaam = "Ai", Familienaam = "Sugiyama" }, new ASSWerknemer1 { WerknemerId = 05, Voornaam = "Akgul", Familienaam = "Amanmuradova" }, new ASSWerknemer1 { WerknemerId = 06, Voornaam = "Albert", Familienaam = "Montanes" }, new ASSWerknemer1 { WerknemerId = 07, Voornaam = "Alberto", Familienaam = "Martin" }, new ASSWerknemer1 { WerknemerId = 08, Voornaam = "Aleksandra", Familienaam = "Wozniak" }, new ASSWerknemer1 { WerknemerId = 09, Voornaam = "Alisa", Familienaam = "Kleybanova" }, new ASSWerknemer1 { WerknemerId = 10, Voornaam = "Alize", Familienaam = "Cornet" }, new ASSWerknemer1 { WerknemerId = 11, Voornaam = "Alla", Familienaam = "Kudryavtseva" }, new ASSWerknemer1 { WerknemerId = 12, Voornaam = "Alona", Familienaam = "Bondarenko" }, new ASSWerknemer1 { WerknemerId = 13, Voornaam = "Amelie", Familienaam = "Mauresmo" }, new ASSWerknemer1 { WerknemerId = 14, Voornaam = "Ana", Familienaam = "Ivanovic" }, new ASSWerknemer1 { WerknemerId = 15, Voornaam = "Anabel", Familienaam = "Medina Garrigues" }, new ASSWerknemer1 { WerknemerId = 16, Voornaam = "Anastasia", Familienaam = "Pavlyuchenkova" }, new ASSWerknemer1 { WerknemerId = 17, Voornaam = "Anastasiya", Familienaam = "Yakimova" }, new ASSWerknemer1 { WerknemerId = 18, Voornaam = "Andreas", Familienaam = "Beck" }, new ASSWerknemer1 { WerknemerId = 19, Voornaam = "Andreas", Familienaam = "Seppi" }, new ASSWerknemer1 { WerknemerId = 20, Voornaam = "Andy", Familienaam = "Murray" }, new ASSWerknemer1 { WerknemerId = 21, Voornaam = "Andy", Familienaam = "Roddick" }, new ASSWerknemer1 { WerknemerId = 22, Voornaam = "Anna", Familienaam = "Chakvetadze" }, new ASSWerknemer1 { WerknemerId = 23, Voornaam = "Anna-Lena", Familienaam = "Groenefeld" }, new ASSWerknemer1 { WerknemerId = 24, Voornaam = "Anne", Familienaam = "Keothavong" }, new ASSWerknemer1 { WerknemerId = 25, Voornaam = "Aravane", Familienaam = "Rezai" }, new ASSWerknemer1 { WerknemerId = 26, Voornaam = "Arnaud", Familienaam = "Clement" }, new ASSWerknemer1 { WerknemerId = 27, Voornaam = "Ayumi", Familienaam = "Morita" }, new ASSWerknemer1 { WerknemerId = 28, Voornaam = "Barbora", Familienaam = "Zahlavova Strycova" }, new ASSWerknemer1 { WerknemerId = 29, Voornaam = "Bethanie", Familienaam = "Mattek-Sands" }, new ASSWerknemer1 { WerknemerId = 30, Voornaam = "Bjorn", Familienaam = "Phau" }, new ASSWerknemer1 { WerknemerId = 31, Voornaam = "Bobby", Familienaam = "Reynolds" },
                    new ASSWerknemer1 { WerknemerId = 32, Voornaam = "Brian", Familienaam = "Dabul" }, new ASSWerknemer1 { WerknemerId = 33, Voornaam = "Camille", Familienaam = "Pin" }, new ASSWerknemer1 { WerknemerId = 34, Voornaam = "Carla", Familienaam = "Suarez Navarro" }, new ASSWerknemer1 { WerknemerId = 35, Voornaam = "Carlos", Familienaam = "Moya" }, new ASSWerknemer1 { WerknemerId = 36, Voornaam = "Caroline", Familienaam = "Wozniacki" }, new ASSWerknemer1 { WerknemerId = 37, Voornaam = "Casey", Familienaam = "Dellacqua" }, new ASSWerknemer1 { WerknemerId = 38, Voornaam = "Christophe", Familienaam = "Rochus" }, new ASSWerknemer1 { WerknemerId = 39, Voornaam = "Daniel", Familienaam = "Gimeno" }, new ASSWerknemer1 { WerknemerId = 40, Voornaam = "Daniela", Familienaam = "Hantuchova" }, new ASSWerknemer1 { WerknemerId = 41, Voornaam = "David", Familienaam = "Ferrer" }, new ASSWerknemer1 { WerknemerId = 42, Voornaam = "David", Familienaam = "Nalbandian" }, new ASSWerknemer1 { WerknemerId = 43, Voornaam = "Denis", Familienaam = "Gremelmayr" }, new ASSWerknemer1 { WerknemerId = 44, Voornaam = "Diego", Familienaam = "Junqueira" }, new ASSWerknemer1 { WerknemerId = 45, Voornaam = "Dinara", Familienaam = "Safina" }, new ASSWerknemer1 { WerknemerId = 46, Voornaam = "Dmitry", Familienaam = "Tursunov" }, new ASSWerknemer1 { WerknemerId = 47, Voornaam = "Dominika", Familienaam = "Cibulkova" }, new ASSWerknemer1 { WerknemerId = 48, Voornaam = "Dudi", Familienaam = "Sela" }, new ASSWerknemer1 { WerknemerId = 49, Voornaam = "Edina", Familienaam = "Gallovits" }, new ASSWerknemer1 { WerknemerId = 50, Voornaam = "Eduardo", Familienaam = "Schwank" }, new ASSWerknemer1 { WerknemerId = 51, Voornaam = "Ekaterina", Familienaam = "Makarova" }, new ASSWerknemer1 { WerknemerId = 52, Voornaam = "Elena", Familienaam = "Dementieva" }, new ASSWerknemer1 { WerknemerId = 53, Voornaam = "Elena", Familienaam = "Vesnina" }, new ASSWerknemer1 { WerknemerId = 54, Voornaam = "Ernests", Familienaam = "Gulbis" }, new ASSWerknemer1 { WerknemerId = 55, Voornaam = "Evgueni", Familienaam = "Korolev" }, new ASSWerknemer1 { WerknemerId = 56, Voornaam = "Fabrice", Familienaam = "Santoro" }, new ASSWerknemer1 { WerknemerId = 57, Voornaam = "Feliciano", Familienaam = "Lopez" }, new ASSWerknemer1 { WerknemerId = 58, Voornaam = "Fernando", Familienaam = "Gonzalez" }, new ASSWerknemer1 { WerknemerId = 59, Voornaam = "Fernando", Familienaam = "Verdasco" }, new ASSWerknemer1 { WerknemerId = 60, Voornaam = "Flavia", Familienaam = "Pennetta" }, new ASSWerknemer1 { WerknemerId = 61, Voornaam = "Florent", Familienaam = "Serra" }, new ASSWerknemer1 { WerknemerId = 62, Voornaam = "Francesca", Familienaam = "Schiavone" }, new ASSWerknemer1 { WerknemerId = 63, Voornaam = "Frederico", Familienaam = "Gil" }, new ASSWerknemer1 { WerknemerId = 64, Voornaam = "Gael", Familienaam = "Monfils" }, new ASSWerknemer1 { WerknemerId = 65, Voornaam = "Galina", Familienaam = "Voskoboeva" }, new ASSWerknemer1 { WerknemerId = 66, Voornaam = "Gilles", Familienaam = "Muller" }, new ASSWerknemer1 { WerknemerId = 67, Voornaam = "Gilles", Familienaam = "Simon" }, new ASSWerknemer1 { WerknemerId = 68, Voornaam = "Gisela", Familienaam = "Dulko" }, new ASSWerknemer1 { WerknemerId = 69, Voornaam = "Guillermo", Familienaam = "Canas" }, new ASSWerknemer1 { WerknemerId = 70, Voornaam = "Guillermo", Familienaam = "Garcia-Lopez" }, new ASSWerknemer1 { WerknemerId = 71, Voornaam = "Igor", Familienaam = "Andreev" }, new ASSWerknemer1 { WerknemerId = 72, Voornaam = "Igor", Familienaam = "Kunitsyn" }, new ASSWerknemer1 { WerknemerId = 73, Voornaam = "Ivan", Familienaam = "Ljubicic" }, new ASSWerknemer1 { WerknemerId = 74, Voornaam = "Ivan", Familienaam = "Navarro-Pastor" }, new ASSWerknemer1 { WerknemerId = 75, Voornaam = "Iveta", Familienaam = "Benesova" }, new ASSWerknemer1 { WerknemerId = 76, Voornaam = "Ivo", Familienaam = "Karlovic" }, new ASSWerknemer1 { WerknemerId = 77, Voornaam = "James", Familienaam = "Blake" }, new ASSWerknemer1 { WerknemerId = 78, Voornaam = "Jan", Familienaam = "Hernych" }, new ASSWerknemer1 { WerknemerId = 79, Voornaam = "Janko", Familienaam = "Tipsarevic" }, new ASSWerknemer1 { WerknemerId = 80, Voornaam = "Jarkko", Familienaam = "Nieminen" }, new ASSWerknemer1 { WerknemerId = 81, Voornaam = "Jarmila", Familienaam = "Groth" }, new ASSWerknemer1 { WerknemerId = 82, Voornaam = "Jelena", Familienaam = "Dokic" }, new ASSWerknemer1 { WerknemerId = 83, Voornaam = "Jelena", Familienaam = "Jankovic" }, new ASSWerknemer1 { WerknemerId = 84, Voornaam = "Jeremy", Familienaam = "Chardy" }, new ASSWerknemer1 { WerknemerId = 85, Voornaam = "Jie", Familienaam = "Zheng" }, new ASSWerknemer1 { WerknemerId = 86, Voornaam = "Jose", Familienaam = "Acasuso" }, new ASSWerknemer1 { WerknemerId = 87, Voornaam = "Jo-Wilfried", Familienaam = "Tsonga" }, new ASSWerknemer1 { WerknemerId = 88, Voornaam = "Juan", Familienaam = "Carlos Ferrero" }, new ASSWerknemer1 { WerknemerId = 89, Voornaam = "Juan", Familienaam = "Martin Del Potro" }, new ASSWerknemer1 { WerknemerId = 90, Voornaam = "Juan", Familienaam = "Monaco" }, new ASSWerknemer1 { WerknemerId = 91, Voornaam = "Julie", Familienaam = "Coin" }, new ASSWerknemer1 { WerknemerId = 92, Voornaam = "Julien", Familienaam = "Benneteau" }, new ASSWerknemer1 { WerknemerId = 93, Voornaam = "Jurgen", Familienaam = "Melzer" }, new ASSWerknemer1 { WerknemerId = 94, Voornaam = "Kaia", Familienaam = "Kanepi" }, new ASSWerknemer1 { WerknemerId = 95, Voornaam = "Katarina", Familienaam = "Srebotnik" }, new ASSWerknemer1 { WerknemerId = 96, Voornaam = "Kateryna", Familienaam = "Bondarenko" }, new ASSWerknemer1 { WerknemerId = 97, Voornaam = "Kei", Familienaam = "Nishikori" }, new ASSWerknemer1 { WerknemerId = 98, Voornaam = "Kirsten", Familienaam = "Flipkens" }, new ASSWerknemer1 { WerknemerId = 99, Voornaam = "Klara", Familienaam = "Zakopalova" }, new ASSWerknemer1 { WerknemerId = 100, Voornaam = "Kristina", Familienaam = "Barrois" }, new ASSWerknemer1 { WerknemerId = 101, Voornaam = "Kristof", Familienaam = "Vliegen" }, new ASSWerknemer1 { WerknemerId = 102, Voornaam = "Leonardo", Familienaam = "Mayer" }, new ASSWerknemer1 { WerknemerId = 103, Voornaam = "Lleyton", Familienaam = "Hewitt" }, new ASSWerknemer1 { WerknemerId = 104, Voornaam = "Lourdes", Familienaam = "Dominguez Lino" }, new ASSWerknemer1 { WerknemerId = 105, Voornaam = "Lucie", Familienaam = "Hradecka" }, new ASSWerknemer1 { WerknemerId = 106, Voornaam = "Lucie", Familienaam = "Safarova" }, new ASSWerknemer1 { WerknemerId = 107, Voornaam = "Magdalena", Familienaam = "Rybarikova" }, new ASSWerknemer1 { WerknemerId = 108, Voornaam = "Marat", Familienaam = "Safin" }, new ASSWerknemer1 { WerknemerId = 109, Voornaam = "Marc", Familienaam = "Gicquel" }, new ASSWerknemer1 { WerknemerId = 110, Voornaam = "Marcel", Familienaam = "Granollers" }, new ASSWerknemer1 { WerknemerId = 111, Voornaam = "Marcos", Familienaam = "Baghdatis" }, new ASSWerknemer1 { WerknemerId = 112, Voornaam = "Mardy", Familienaam = "Fish" }, new ASSWerknemer1 { WerknemerId = 113, Voornaam = "Maret", Familienaam = "Ani" }, new ASSWerknemer1 { WerknemerId = 114, Voornaam = "Maria", Familienaam = "Jose Martinez Sanchez" }, new ASSWerknemer1 { WerknemerId = 115, Voornaam = "Maria", Familienaam = "Kirilenko" }, new ASSWerknemer1 { WerknemerId = 116, Voornaam = "Maria", Familienaam = "Sharapova" }, new ASSWerknemer1 { WerknemerId = 117, Voornaam = "Marin", Familienaam = "Cilic" }, new ASSWerknemer1 { WerknemerId = 118, Voornaam = "Marina", Familienaam = "Erakovic" }, new ASSWerknemer1 { WerknemerId = 119, Voornaam = "Mario", Familienaam = "Ancic" }, new ASSWerknemer1 { WerknemerId = 120, Voornaam = "Marion", Familienaam = "Bartoli" }, new ASSWerknemer1 { WerknemerId = 121, Voornaam = "Mariya", Familienaam = "Koryttseva" }, new ASSWerknemer1 { WerknemerId = 122, Voornaam = "Martin", Familienaam = "Vassallo-Arguello" }, new ASSWerknemer1 { WerknemerId = 123, Voornaam = "Mathilde", Familienaam = "Johansson" }, new ASSWerknemer1 { WerknemerId = 124, Voornaam = "Maximo", Familienaam = "Gonzalez" }, new ASSWerknemer1 { WerknemerId = 125, Voornaam = "Melinda", Familienaam = "Czink" }, new ASSWerknemer1 { WerknemerId = 126, Voornaam = "Michael", Familienaam = "Llodra" }, new ASSWerknemer1 { WerknemerId = 127, Voornaam = "Michael", Familienaam = "Zverev" }, new ASSWerknemer1 { WerknemerId = 128, Voornaam = "Mikhail", Familienaam = "Youzhny" }, new ASSWerknemer1 { WerknemerId = 129, Voornaam = "Monica", Familienaam = "Niculescu" }, new ASSWerknemer1 { WerknemerId = 130, Voornaam = "Na", Familienaam = "Li" }, new ASSWerknemer1 { WerknemerId = 131, Voornaam = "Nadia", Familienaam = "Petrova" }, new ASSWerknemer1 { WerknemerId = 132, Voornaam = "Nathalie", Familienaam = "Dechy" }, new ASSWerknemer1 { WerknemerId = 133, Voornaam = "Nicolas", Familienaam = "Almagro" }, new ASSWerknemer1 { WerknemerId = 134, Voornaam = "Nicolas", Familienaam = "Devilder" }, new ASSWerknemer1 { WerknemerId = 135, Voornaam = "Nicolas", Familienaam = "Kiefer" }, new ASSWerknemer1 { WerknemerId = 136, Voornaam = "Nicolas", Familienaam = "Massu" }, new ASSWerknemer1 { WerknemerId = 137, Voornaam = "Nicole", Familienaam = "Vaidisova" }, new ASSWerknemer1 { WerknemerId = 138, Voornaam = "Nikolay", Familienaam = "Davydenko" }, new ASSWerknemer1 { WerknemerId = 139, Voornaam = "Novak", Familienaam = "Djokovic" }, new ASSWerknemer1 { WerknemerId = 140, Voornaam = "Olga", Familienaam = "Govortsova" }, new ASSWerknemer1 { WerknemerId = 141, Voornaam = "Oscar", Familienaam = "Hernandez" }, new ASSWerknemer1 { WerknemerId = 142, Voornaam = "Pablo", Familienaam = "Andujar" }, new ASSWerknemer1 { WerknemerId = 143, Voornaam = "Patricia", Familienaam = "Mayr" }, new ASSWerknemer1 { WerknemerId = 144, Voornaam = "Patty", Familienaam = "Schnyder" }, new ASSWerknemer1 { WerknemerId = 145, Voornaam = "Paul", Familienaam = "Capdeville" }, new ASSWerknemer1 { WerknemerId = 146, Voornaam = "Paul-Henri", Familienaam = "Mathieu" }, new ASSWerknemer1 { WerknemerId = 147, Voornaam = "Pauline", Familienaam = "Parmentier" }, new ASSWerknemer1 { WerknemerId = 148, Voornaam = "Petra", Familienaam = "Cetkovska" }, new ASSWerknemer1 { WerknemerId = 149, Voornaam = "Petra", Familienaam = "Kvitova" }, new ASSWerknemer1 { WerknemerId = 150, Voornaam = "Philipp", Familienaam = "Kohlschreiber" },
                    new ASSWerknemer1 { WerknemerId = 151, Voornaam = "Philipp", Familienaam = "Petzschner" }, new ASSWerknemer1 { WerknemerId = 152, Voornaam = "Potito", Familienaam = "Starace" }, new ASSWerknemer1 { WerknemerId = 153, Voornaam = "Radek", Familienaam = "Stepanek" }, new ASSWerknemer1 { WerknemerId = 154, Voornaam = "Rafael", Familienaam = "Nadal" }, new ASSWerknemer1 { WerknemerId = 155, Voornaam = "Rainer", Familienaam = "Schuettler" }, new ASSWerknemer1 { WerknemerId = 156, Voornaam = "Richard", Familienaam = "Gasquet" }, new ASSWerknemer1 { WerknemerId = 157, Voornaam = "Robby", Familienaam = "Ginepri" }, new ASSWerknemer1 { WerknemerId = 158, Voornaam = "Robert", Familienaam = "Kendrick" }, new ASSWerknemer1 { WerknemerId = 159, Voornaam = "Roberta", Familienaam = "Vinci" }, new ASSWerknemer1 { WerknemerId = 160, Voornaam = "Robin", Familienaam = "Soderling" }, new ASSWerknemer1 { WerknemerId = 161, Voornaam = "Roger", Familienaam = "Federer" }, new ASSWerknemer1 { WerknemerId = 162, Voornaam = "Rossana", Familienaam = "De Los Rios" }, new ASSWerknemer1 { WerknemerId = 163, Voornaam = "Sabine", Familienaam = "Lisicki" }, new ASSWerknemer1 { WerknemerId = 164, Voornaam = "Samantha", Familienaam = "Stosur" }, new ASSWerknemer1 { WerknemerId = 165, Voornaam = "Samuel", Familienaam = "Querrey" }, new ASSWerknemer1 { WerknemerId = 166, Voornaam = "Sania", Familienaam = "Mirza" }, new ASSWerknemer1 { WerknemerId = 167, Voornaam = "Sara", Familienaam = "Errani" }, new ASSWerknemer1 { WerknemerId = 168, Voornaam = "Serena", Familienaam = "Williams" }, new ASSWerknemer1 { WerknemerId = 169, Voornaam = "Severine", Familienaam = "Bremond" }, new ASSWerknemer1 { WerknemerId = 170, Voornaam = "Shahar", Familienaam = "Peer" }, new ASSWerknemer1 { WerknemerId = 171, Voornaam = "Shuai", Familienaam = "Peng" }, new ASSWerknemer1 { WerknemerId = 172, Voornaam = "Simone", Familienaam = "Bolelli" }, new ASSWerknemer1 { WerknemerId = 173, Voornaam = "Sofia", Familienaam = "Arvidsson" }, new ASSWerknemer1 { WerknemerId = 174, Voornaam = "Sorana", Familienaam = "Cirstea" }, new ASSWerknemer1 { WerknemerId = 175, Voornaam = "Stanislas", Familienaam = "Wawrinka" }, new ASSWerknemer1 { WerknemerId = 176, Voornaam = "Stephanie", Familienaam = "Cohen-Aloro" }, new ASSWerknemer1 { WerknemerId = 177, Voornaam = "Svetlana", Familienaam = "Kuznetsova" }, new ASSWerknemer1 { WerknemerId = 178, Voornaam = "Sybille", Familienaam = "Bammer" }, new ASSWerknemer1 { WerknemerId = 179, Voornaam = "Tamarine", Familienaam = "Tanasugarn" }, new ASSWerknemer1 { WerknemerId = 180, Voornaam = "Tamira", Familienaam = "Paszek" }, new ASSWerknemer1 { WerknemerId = 181, Voornaam = "Tathiana", Familienaam = "Garbin" }, new ASSWerknemer1 { WerknemerId = 182, Voornaam = "Teimuraz", Familienaam = "Gabashvili" }, new ASSWerknemer1 { WerknemerId = 183, Voornaam = "Thomaz", Familienaam = "Bellucci" }, new ASSWerknemer1 { WerknemerId = 184, Voornaam = "Timea", Familienaam = "Bacsinszky" }, new ASSWerknemer1 { WerknemerId = 185, Voornaam = "Tomas", Familienaam = "Berdych" }, new ASSWerknemer1 { WerknemerId = 186, Voornaam = "Tommy", Familienaam = "Haas" }, new ASSWerknemer1 { WerknemerId = 187, Voornaam = "Tommy", Familienaam = "Robredo" }, new ASSWerknemer1 { WerknemerId = 188, Voornaam = "Tsvetana", Familienaam = "Pironkova" }, new ASSWerknemer1 { WerknemerId = 189, Voornaam = "Vania", Familienaam = "King" }, new ASSWerknemer1 { WerknemerId = 190, Voornaam = "Venus", Familienaam = "Williams" }, new ASSWerknemer1 { WerknemerId = 191, Voornaam = "Vera", Familienaam = "Dushevina" }, new ASSWerknemer1 { WerknemerId = 192, Voornaam = "Vera", Familienaam = "Zvonareva" }, new ASSWerknemer1 { WerknemerId = 193, Voornaam = "Victor", Familienaam = "Hanescu" }, new ASSWerknemer1 { WerknemerId = 194, Voornaam = "Victoria", Familienaam = "Azarenka" }, new ASSWerknemer1 { WerknemerId = 195, Voornaam = "Viktor", Familienaam = "Troicki" }, new ASSWerknemer1 { WerknemerId = 196, Voornaam = "Virginie", Familienaam = "Razzano" }, new ASSWerknemer1 { WerknemerId = 197, Voornaam = "Wayne", Familienaam = "Odesnik" }, new ASSWerknemer1 { WerknemerId = 198, Voornaam = "Yanina", Familienaam = "Wickmayer" }, new ASSWerknemer1 { WerknemerId = 199, Voornaam = "Yen-Hsun", Familienaam = "Lu" }, new ASSWerknemer1 { WerknemerId = 200, Voornaam = "Yung-Jan", Familienaam = "Chan" } 
                };
                foreach (var werknemer in werknemers) 
                { 
                    if (werknemer.WerknemerId % 3 != 0) 
                    { 
                        werknemer.OversteId = (1 + ((werknemer.Voornaam.Length * werknemer.Familienaam.Length) % werknemer.WerknemerId)); 
                    } 
                }
                foreach (var werknemer in werknemers) 
                { 
                    if (werknemer.OversteId == werknemer.WerknemerId) 
                    { 
                        werknemer.OversteId = null; 
                    } 
                }
                modelBuilder.Entity<ASSWerknemer1>().HasData(werknemers);

            }


        }
    }
}
