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
                // Creation du jeu de données
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
                

                // 1. Récupérer un article par son Id
                Console.WriteLine("Selection d'un article");
                var articleById = db.Article
                    .Find(1);
                Console.WriteLine("Id: " + articleById.Id);
                Console.WriteLine("Libelle: " + articleById.Libelle);
                Console.WriteLine("Poids: " + articleById.Poids);
                Console.WriteLine("PrixInitial: " + articleById.PrixInitial);
                Console.WriteLine("SKU: " + articleById.SKU);
                Console.WriteLine("Date de sortie" + articleById.DateSortie);
                Console.WriteLine("");


                // 2. Récupérer la totalité des articles
                Console.WriteLine("***** Liste des articles *****");
                var tableArticle = db.Article;
                var listArticle =
                    (from article in tableArticle
                     select new {
                         id = article.Id,
                         libelle = article.Libelle,
                         poids = article.Poids,
                         prixinitial = article.PrixInitial,
                         sku = article.SKU,
                         datesortie = article.DateSortie,
                     });

                foreach (var article in listArticle)
                {
                    Console.WriteLine("*****" + article.id + "*****");
                    Console.WriteLine(
                    "Id : {0}, Libellé : {1}, SKU : {2}, Date de sortie : {3}, Prix initial : {4}, Poids : {5}",
                    article.id, article.libelle, article.poids, article.prixinitial, article.sku, article.datesortie);
                    Console.WriteLine("*******");
                }
                Console.WriteLine("");


                // 3. Ajouter/modifier/supprimer un article
                Console.WriteLine("Selection d'un article");
                var articleRUD = db.Article
                    .OrderBy(b => b.Id)
                    .First();

                Console.WriteLine("Modification de l'article");
                articleRUD.Libelle = "Libelle modifié";
                db.SaveChanges();

                Console.WriteLine("Suppression de l'article");
                db.Remove(articleRUD);
                db.SaveChanges();
                Console.WriteLine("");

                // 4. Récupérer le prix moyen par secteur
                Console.WriteLine("***** Prix moyen par secteur *****");
                var prixMoyenParSecteur =
                    (from Article in tableArticle
                     join Position in db.PositionMagasin on Article.Id equals Position.IdArticle
                     join Etagere in db.Etagere on Position.IdEtagere equals Etagere.Id
                     join Secteur in db.Secteur on Etagere.IdSecteur equals Secteur.Id

                     select new
                     {
                         nomSecteur = Secteur.Nom,
                         moyenne = (Article.PrixInitial * Position.Quantite),
                     });

                foreach (var article in prixMoyenParSecteur)
                {
                    Console.WriteLine("Secteur : {0},  Moyenne : {1}",
                        article.nomSecteur, article.moyenne);
                }
            }
        }
    }
}
