using System;
using System.Collections.Generic;
using System.Text;

namespace TPArticle
{
    public class Secteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public List<Etagere> Etageres { get; } = new List<Etagere>();
        public Secteur(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public Secteur()
        {
        }
    }
}
