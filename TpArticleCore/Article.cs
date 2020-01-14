using System;
using System.Collections.Generic;
using System.Text;

namespace TPArticle
{
    public class Article
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string SKU { get; set; }
        public DateTime DateSortie { get; set; }
        public decimal PrixInitial { get; set; }
        public decimal Poids { get; set; }

        public Article(int id, string libelle, string sKU, DateTime dateSortie, decimal prixInitial, decimal poids)
        {
            Id = id;
            Libelle = libelle;
            SKU = sKU;
            DateSortie = dateSortie;
            PrixInitial = prixInitial;
            Poids = poids;
        }
        public Article()
        {
        }
    }
}
