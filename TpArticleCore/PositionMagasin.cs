using System;
using System.Collections.Generic;
using System.Text;

namespace TPArticle
{
    public class PositionMagasin
    {
        public int Id { get; set; }
        public int IdArticle { get; set; }
        public int IdEtagere { get; set; }
        public int Quantite { get; set; }

        public PositionMagasin(int idArticle, int idEtagere, int quantite)
        {
            IdArticle = idArticle;
            IdEtagere = idEtagere;
            Quantite = quantite;
        }
        public PositionMagasin()
        {
        }
    }
}
