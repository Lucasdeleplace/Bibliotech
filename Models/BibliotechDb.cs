using Microsoft.EntityFrameworkCore;

namespace bibliotech.Models
{
    public class BibliotechDb : DbContext
    {
        public DbSet<Membre> Membre { get; set; }

        public BibliotechDb(DbContextOptions<BibliotechDb> options)
            : base(options)
        {

        }
    }
}