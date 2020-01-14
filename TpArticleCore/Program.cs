using System;
using System.Linq;

namespace TPArticle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new Model())
            {
                // Create
                db.Add(new Secteur { 
                    Id = 1, 
                    Nom = "Secteur A" 
                });
                db.Add(new Secteur { 
                    Id = 2, 
                    Nom = "Secteur B" 
                });
                Console.WriteLine("Nouveaux Secteurs insérés avec succès");

                db.Add(new Etagere { 
                    Id = 1, 
                    PoidsMaximum = 15000, 
                    IdSecteur = 1 
                });
                db.Add(new Etagere { 
                    Id = 2, 
                    PoidsMaximum = 17000, 
                    IdSecteur = 1 
                });
                db.Add(new Etagere { 
                    Id = 3, 
                    PoidsMaximum = 15500, 
                    IdSecteur = 2 
                });
                db.Add(new Etagere { 
                    Id = 4, 
                    PoidsMaximum = 12000, 
                    IdSecteur = 2 
                });
                Console.WriteLine("Nouvelles Etagères insérées avec succès");

                db.Add(new Article { 
                    Id = 1, 
                    Libelle = "Tablette", 
                    SKU = "123456", 
                    DateSortie = new DateTime(2019,02,10), 
                    PrixInitial = 499.99m, 
                    Poids = 499
                });
                db.Add(new Article
                {
                    Id = 2,
                    Libelle = "Telephone",
                    SKU = "789101",
                    DateSortie = new DateTime(2019, 03, 02),
                    PrixInitial = 299.59m,
                    Poids = 258
                });
                db.Add(new Article
                {
                    Id = 3,
                    Libelle = "PC",
                    SKU = "147852",
                    DateSortie = new DateTime(2018, 05, 05),
                    PrixInitial = 1566.23m,
                    Poids = 1890
                });
                db.Add(new Article
                {
                    Id = 4,
                    Libelle = "Bureau",
                    SKU = "258963",
                    DateSortie = new DateTime(2010, 06, 02),
                    PrixInitial = 350m,
                    Poids = 9500
                });
                Console.WriteLine("Nouveaux Articles insérés avec succès");

                db.Add(new PositionMagasin
                {
                    IdArticle = 1,
                    IdEtagere = 1,
                    Quantite = 10
                });
                db.Add(new PositionMagasin
                {
                    IdArticle = 2,
                    IdEtagere = 1,
                    Quantite = 2
                });
                db.Add(new PositionMagasin
                {
                    IdArticle = 1,
                    IdEtagere = 3,
                    Quantite = 15
                });
                Console.WriteLine("Nouvelles PositionMagasin insérées avec succès");
                
                db.SaveChanges();
                Console.WriteLine("");

                // Read
                Console.WriteLine("Lecture de l'étagere avec l'id le plus petit :");
                var etagere = db.Etagere
                    .OrderBy(b => b.Id)
                    .First();
                Console.WriteLine("Id: " + etagere.Id);
                Console.WriteLine("PoidsMaximum: " + etagere.PoidsMaximum);
                Console.WriteLine("IdSecteur: " + etagere.IdSecteur);
                Console.WriteLine("");

                // Update
                etagere.PoidsMaximum = 150;
                db.SaveChanges();
                Console.WriteLine("Modification de l'etagere");
                Console.WriteLine("");

                // Delete
                db.Remove(etagere);
                db.SaveChanges();
                Console.WriteLine("Suppression de l'etagere");
                Console.WriteLine("");
            }
        }
    }
}
