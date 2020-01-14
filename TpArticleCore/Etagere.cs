using System;
using System.Collections.Generic;
using System.Text;

namespace TPArticle
{
    public class Etagere
    {
        public int Id { get; set; }
        public decimal PoidsMaximum { get; set; }
        public int IdSecteur { get; set; }

        public List<Article> Articles { get; } = new List<Article>();

        public Etagere(int id, decimal poidsMaximum, int idSecteur)
        {
            Id = id;
            PoidsMaximum = poidsMaximum;
            IdSecteur = idSecteur;
        }

        public Etagere()
        {
        }
    }
}
