using Microsoft.EntityFrameworkCore;

namespace TPArticle
{
    public class Model : DbContext
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<PositionMagasin> PositionMagasin { get; set; }
        public DbSet<Etagere> Etagere { get; set; }
        public DbSet<Secteur> Secteur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=TpArticle.db");
    }
}
