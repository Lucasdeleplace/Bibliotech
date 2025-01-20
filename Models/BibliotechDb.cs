using Microsoft.EntityFrameworkCore;

namespace bibliotech.Models
{
    public class BibliotechDb : DbContext
    {
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Livre> Livres { get; set; }

        public BibliotechDb(DbContextOptions<BibliotechDb> options)
            : base(options)
        {

        }
    }
}