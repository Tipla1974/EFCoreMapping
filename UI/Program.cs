using System;
using System.Reflection;
using Model.Entities;
using Model.Repositories;

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

    }

}
