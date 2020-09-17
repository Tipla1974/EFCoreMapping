using System;
using System.Reflection;
using Model.Entities;
using Model.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Transactions;


namespace UI
{
    public class Program
    {
        //private static readonly EFOpleidingenContext context = new EFOpleidingenContext(); 
        static void Main(string[] args) 
        { 
            string keuze = string.Empty; 
            while (keuze.ToUpper() != "X") 
            { 
                Console.ForegroundColor = ConsoleColor.Yellow; 
                Console.WriteLine("----"); 
                Console.WriteLine("Menu"); 
                Console.WriteLine("----"); 
                Console.WriteLine(" 1 - Menu item");
                Console.WriteLine(" 2 - Menu item");
                Console.WriteLine(" 3 - Menu item");
                Console.WriteLine(" 4 - Menu item");
                //Console.WriteLine(" . . . . "); 
                // . . . . 
                // P l a a t s h i e r d e v e r s c h i l l e n d e m e n u i t e m s 
                // . . . . 

                Console.Write("Keuze ('X' om te stoppen): "); 
                keuze = Console.ReadLine(); 
                Console.WriteLine("----------------------------------------------------------\n"); 
                Console.ForegroundColor = ConsoleColor.Blue;
                if (keuze.ToUpper() != "X")
                { 
                    // Reflection 
                    Program p = new Program(); 
                    Type t = p.GetType(); 
                    try 
                    { 
                        MethodInfo mi = t.GetMethod("Item" + "00".Substring(0, -keuze.Length + 2) + keuze, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static); 
                        mi.Invoke(p, null); 
                        
                        //string result = mi.Invoke(p, new object[] { par1, par2 }).ToString(); 
                    } 
                    catch 
                    { 
                        Console.WriteLine("Ongeldige keuze"); 
                    } 
                } 
                
                //switch (keuze) 
                //{ // case "X": case "x": break; 
                // case "1": { Item01(); break; } 
                // 
                // . . . . 
                // 
                // default: 
                // { 
                // Console.WriteLine("Ongeldige keuze"); 
                // break; 
                // } 
                //} 
                // === 
                // End 
                // === 
                if (keuze.ToUpper() == "X") 
                    break; 
                Console.WriteLine("\nDruk een toets"); 
                Console.ReadKey(); 
                Console.Clear(); 
            } 
        } 
        
        // --------- 
        // Menu-item 
        // --------- 

        // 1. Owned Types / Complex Types 
        static void Item01() 
        { 
            using var context = new EFCoreMappingContext(); 
            var campus = new Campus 
            { 
                Naam = "VDAB Wondelgem", 
                Adres = new Adres
                { 
                    Straat = "Industrieweg", 
                    Huisnummer = "50", 
                    Postcode = "9032", 
                    Gemeente = "Gent" 
                }
            }; 
            var johan = new Docent 
            { 
                Voornaam = "Johan", 
                Familienaam = "Vandaele", 
                Wedde = 1000m, 
                InDienst = new DateTime(2016, 2, 1), 
                HeeftRijbewijs = true, 
                AdresThuis = new Adres 
                { 
                    Straat = "Ter Lake", 
                    Huisnummer = "7", 
                    Postcode = "8310", 
                    Gemeente = "Brugge" 
                }, 
                AdresWerk = new Adres 
                { 
                    Straat = "Hertsbergsestraat", 
                    Huisnummer = "91", 
                    Postcode = "8020", 
                    Gemeente = "Oostkamp" 
                }, 
                Campus = campus 
            }; 
            context.Add(johan); 
            context.SaveChanges();
        }
        // 2. Inheritance: TPH 
        static void Item02() 
        { 
            using var context = new EFCoreMappingContext(); 
            context.TPHCursussen.Add(new TPHKlassikaleCursus 
            { 
                Naam = "Frans in 24 uur", 
                Van = DateTime.Today, 
                Tot = DateTime.Today 
            }); 
            context.TPHCursussen.Add(new TPHZelfstudieCursus 
            { 
                Naam = "Engels in 24 uur", 
                AantalDagen = 1 
            }); 
            context.SaveChanges(); 
        }
        // 3. Associaties - Eén op veel 
        static void Item03() 
        { 
            using var context = new EFCoreMappingContext(); 
            var campus = new ASSCampus 
            { 
                Naam = "Delos", 
                Adres = new Adres 
                { 
                    Straat = "Vlamingstraat", 
                    Huisnummer = "10", 
                    Postcode = "8560", 
                    Gemeente = "Wevelgem" 
                } 
            }; 
            var docent1 = new ASSDocent 
            { 
                Voornaam = "Marcel",
                Familienaam = "Kiekeboe",
                Wedde = 100,
                InDienst = new DateTime(1955, 1, 1),
                HeeftRijbewijs = true,
                Adres = new Adres { Straat = "Merholaan", Huisnummer = "1B", Postcode = "2981", Gemeente = "Zoersel-Parwijs" },
                ASSCampus = campus
            }; 
            var docent2 = new ASSDocent 
            { 
                Voornaam = "Fanny", 
                Familienaam = "Kiekeboe", 
                Wedde = 100, 
                InDienst = new DateTime(1992, 1, 1), 
                HeeftRijbewijs = true, 
                Adres = new Adres 
                { 
                    Straat = "Merholaan", 
                    Huisnummer = "1B", 
                    Postcode = "2981", 
                    Gemeente = "Zoersel-Parwijs" 
                }, 
                ASSCampus = campus 
            }; 

            campus.ASSDocenten.Add(docent1); 
            campus.ASSDocenten.Add(docent2); 
            context.ASSCampussen.Add(campus); 
            context.SaveChanges();
        }
        // 4. Associaties - Veel op veel: Een join entity toevoegen 
        static void Item04() 
        { 
            using var context = new EFCoreMappingContext(); 
            context.AssBoekenCursussen.AddRange ( new ASSBoekCursus 
            { 
                BoekId = 1, 
                CursusId = 1, 
                VolgNr = 1 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 2, 
                CursusId = 1, 
                VolgNr = 2 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 3, 
                CursusId = 1, 
                VolgNr = 3 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 4, 
                CursusId = 2, 
                VolgNr = 1 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 5, 
                CursusId = 2, 
                VolgNr = 2 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 4, 
                CursusId = 3, 
                VolgNr = 1 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 5, 
                CursusId = 3, 
                VolgNr = 2 
            }, 
            new ASSBoekCursus 
            { 
                BoekId = 6, 
                CursusId = 3, 
                VolgNr = 3 
            } ); 
            
            context.SaveChanges(); 
        }
        // 5. Associaties - Veel op veel: De entities gebruiken vanuit je code - Voorbeeld 1 
        static void Item05() 
        { 
            using var context = new EFCoreMappingContext(); 
            var cursussen = from cursus in context.AssCursussen.Include("BoekenCursussen.Boek") // (1) of 
                            //var cursussen = from cursus in 
                            // context.AssCursussen.Include(x=>x.BoekenCursussen).ThenInclude(y=>y.Boek) // (1) 
                            orderby cursus.Naam 
                            select cursus; 
            foreach (var cursus in cursussen) 
            { 
                Console.WriteLine(cursus.Naam); 
                foreach (var boekCursus in cursus.BoekenCursussen)
                { 
                    Console.WriteLine($"\t{boekCursus.VolgNr}:{boekCursus.Boek.Titel}"); 
                }
            }
        }
        // 6. Associaties - Veel op veel: De entities gebruiken vanuit je code - Voorbeeld 2 
        static void Item06() 
        { 
            var nieuwBoek = new ASSBoek() 
            { 
                IsbnNr = "0-201-70431-5", 
                Titel = "Modern C++ Design" 
            }; 
            var transactionOptions = new TransactionOptions 
            { 
                IsolationLevel = IsolationLevel.Serializable 
            }; 
            using var transactionScope = new TransactionScope(TransactionScopeOption.Required,transactionOptions); 
            using var context = new EFCoreMappingContext();

            // Cursus C++ ophalen 
            // én het hoogste volgnr. van boek gebruikt in die cursus. 
            // Met transactie met isolation level Serializable 
            // kan daarna niemand anders een boek toevoegen aan C++ cursus
            // en is het nieuwe volgnr gelijk aan 1 + hoogst gelezen volgnr 
            
            var query = from cursus in context.AssCursussen.Include("BoekenCursussen") 
                        where cursus.Naam == "C++" 
                        select new 
                        { 
                            Cursus = cursus, HoogsteVolgnr = cursus.BoekenCursussen.Max(boekCursus => boekCursus.VolgNr) 
                        }; 
            var queryResult = query.FirstOrDefault(); 
            if (queryResult != null) 
            { 
                context.AssBoekenCursussen.Add(new ASSBoekCursus 
                { 
                    Boek = nieuwBoek, 
                    Cursus = queryResult.Cursus, 
                    VolgNr = queryResult.HoogsteVolgnr + 1 
                }); 
                context.SaveChanges(); 
            } 
            transactionScope.Complete(); 
        }
        // 7. Associaties - Veel op veel: De entities gebruiken vanuit je code - Voorbeeld 3 
        static void Item07() 
        { 
            using var context = new EFCoreMappingContext(); 
            var campus = new ASSCampus 
            { 
                Naam = "CC Wondelgem", 
                Adres = new Adres 
                { 
                    Straat = "Industrieweg", 
                    Huisnummer = "50", 
                    Postcode = "9000", 
                    Gemeente = "Wondelgem" 
                } 
            };
            
            var jean = new ASSDocent 
            { 
                Voornaam = "Jean", 
                Familienaam = "Smits", 
                Wedde = 1000m, 
                InDienst = new DateTime(1966, 8, 1), 
                HeeftRijbewijs = true, 
                Adres = new Adres 
                { 
                    Straat = "Keizerslaan", 
                    Huisnummer = "11", 
                    Postcode = "1000", 
                    Gemeente = "Brussel" 
                }, 
                ASSCampus = campus 
            }; 
            
            var kiekeboe = new ASSDocent 
            { 
                Voornaam = "Marcel", 
                Familienaam = "Kiekeboe", 
                Wedde = 500m, 
                InDienst = new DateTime(1948, 10, 24), 
                HeeftRijbewijs = true, 
                Adres = new Adres 
                { 
                    Straat = "Merholaan", 
                    Huisnummer = "1B", 
                    Postcode = "3000", 
                    Gemeente = "Zoersel" 
                }, 
                ASSCampus = campus 
            }; 
            
            var activiteit1 = new ASSActiviteit 
            { 
                Naam = "EHBO" 
            }; 
            
            var activiteit2 = new ASSActiviteit 
            { 
                Naam = "Vergaderen" 
            }; 
            
            var activiteit3 = new ASSActiviteit 
            { 
                Naam = "Overleggen" 
            }; 
            var activiteit4 = new ASSActiviteit 
            { 
                Naam = "Studie" 
            }; 
            context.ASSCampussen.Add(campus); 
            context.SaveChanges(); 
            context.ASSDocenten.Add(jean); 
            context.ASSDocenten.Add(kiekeboe); 
            context.SaveChanges(); 
            context.AssActiviteiten.Add(activiteit1); 
            context.AssActiviteiten.Add(activiteit2); 
            context.AssActiviteiten.Add(activiteit3); 
            context.AssActiviteiten.Add(activiteit4); 
            context.SaveChanges(); 
            
            // Toevoegen Join Entity 
            var join1 = new ASSDocentActiviteit 
                { DocentId = jean.DocentId, ActiviteitId = activiteit2.ActiviteitId }; 
            var join2 = new ASSDocentActiviteit { DocentId = jean.DocentId, ActiviteitId = activiteit3.ActiviteitId }; 
            var join3 = new ASSDocentActiviteit { DocentId = kiekeboe.DocentId, ActiviteitId = activiteit4.ActiviteitId }; 
            var join4 = new ASSDocentActiviteit { DocentId = kiekeboe.DocentId, ActiviteitId = activiteit1.ActiviteitId }; 
            var join5 = new ASSDocentActiviteit { DocentId = kiekeboe.DocentId, ActiviteitId = activiteit2.ActiviteitId }; 
            context.AddRange(join1, join2, join3, join4, join5); 
            context.SaveChanges(); 
        }
        // 8. Associaties - Veel op veel: De entities gebruiken vanuit je code - Voorbeeld 4 
        static void Item08() 
        { 
            using var context = new EFCoreMappingContext(); 
            var docent = context.ASSDocenten.Find(4); 
            docent.DocentenActiviteiten.Add(new ASSDocentActiviteit { ActiviteitId = 3 }); 
            context.SaveChanges(); 
        }
        // 9. Associaties - Veel op veel: De entities gebruiken vanuit je code - Voorbeeld 5 
        static void Item09() 
        { 
            ASSDocent docent; 
            using (var context = new EFCoreMappingContext()) 
            { 
                //docent = context.ASSDocenten.Find(2); 
                docent = context.ASSDocenten.Include("DocentenActiviteiten").FirstOrDefault(d => d.DocentId == 2); 
            } 
            
            if (docent != null) 
            { 
                docent.DocentenActiviteiten.Add(new ASSDocentActiviteit { ActiviteitId=2, AantalUren = 8 }); 
                using var context = new EFCoreMappingContext(); 
                context.ASSDocenten.Attach(docent); 
                // Maakt het mogelijk om bij debugging de gegevens te tonen vooraleer te bewaren 
                context.ChangeTracker.DetectChanges(); 
                // DEBUG - STOP 
                context.SaveChanges(); 
            }
            else { Console.WriteLine("Docent niet gevonden."); }
        }
        // 10. Associaties - Een associatie naar eenzelfde tabel 
        static void Item10() 
        { 
            using var context = new EFCoreMappingContext(); 
            // ================================== 
            // Een associatie naar dezelfde tabel 
            // ================================== 
            ASSWerknemer joe = new ASSWerknemer { Voornaam = "Joe", Familienaam = "Dalton" }; 
            ASSWerknemer averell = new ASSWerknemer { Voornaam = "Averell", Familienaam = "Dalton", Overste = joe };
            context.AssWerknemers.Add(joe);
            context.AssWerknemers.Add(averell);
            // ======================= 
            context.SaveChanges(); 
            Console.WriteLine("Einde"); 
        }
        
        // 11. Associaties - Een associatie naar eenzelfde tabel - Voorbeeld 1 
        static void Item11() 
        { 
            using var context = new EFCoreMappingContext(); 
            var query = from werknemer in context.AssWerknemers1 
                        where werknemer.Overste == null 
                        orderby werknemer.Voornaam, werknemer.Familienaam 
                        select werknemer; 
            Console.WriteLine("\n"); 
            foreach (var werknemer in query) 
            { 
                Console.WriteLine($"{werknemer.Voornaam} {werknemer.Familienaam}"); 
            } 
            Console.WriteLine("\n\n"); 
        
        }
        // 12. Associaties - Een associatie naar eenzelfde tabel - Voorbeeld 2 
        static void Item12() 
        { 
            using var context = new EFCoreMappingContext(); 
            var query = from werknemer in context.AssWerknemers1.Include("Overste") 
                        where werknemer.Overste != null 
                        orderby werknemer.Voornaam, werknemer.Familienaam 
                        select werknemer; 
            Console.WriteLine("\n\n"); 
            foreach (var werknemer in query) 
            { 
                Console.WriteLine($"Werknemer: {werknemer.Voornaam} {werknemer.Familienaam} " + 
                    $"          Overste: {werknemer.Overste.Voornaam} {werknemer.Overste.Familienaam}"); 
            } 
            Console.WriteLine("\n\n"); 
        }
        // 13. Associaties - Een associatie naar eenzelfde tabel - Voorbeeld 3 
        static void Item13() 
        { 
            using var context = new EFCoreMappingContext(); 
            var query = from overste in context.AssWerknemers1.Include("Werknemers") 
                        where overste.Werknemers.Count != 0 
                        orderby overste.Voornaam, overste.Familienaam 
                        select overste; Console.WriteLine("\n\n"); 
            foreach (var overste in query) 
            { 
                Console.WriteLine($"Overste: {overste.Voornaam} {overste.Familienaam}"); 
                foreach (var werknemer in overste.Werknemers) 
                { 
                    Console.WriteLine($"\tWerknemer: {werknemer.Voornaam} {werknemer.Familienaam}"); 
                } 
            } 
            Console.WriteLine("\n\n"); 
        }
        // 14. Associaties - Een associatie naar eenzelfde tabel - Voorbeeld 4 
        static void Item14() 
        { 
            using var context = new EFCoreMappingContext(); 
            var werknemer5 = context.AssWerknemers1.Find(5); 
            if(werknemer5!=null) 
            { 
                var werknemer6 = context.AssWerknemers1.Find(6); 
                if(werknemer6!=null) 
                { 
                    werknemer5.Werknemers.Add(werknemer6); 
                    context.SaveChanges(); 
                } 
                else 
                {
                    Console.WriteLine("Werknemer 6 niet gevonden.");
                }
            }
            else 
            { 
                Console.WriteLine("Werknemer 5 niet gevonden."); }
        }

    }

}
