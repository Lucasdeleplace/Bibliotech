using Microsoft.EntityFrameworkCore;

namespace bibliotech.Models
{
    public class BibliotechDb : DbContext
    {
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Membre> Membre { get; set; }

        public BibliotechDb(DbContextOptions<BibliotechDb> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprunt>()
                .HasOne(e => e.Livre)
                .WithMany()
                .HasForeignKey(e => e.Id_Livre);

            modelBuilder.Entity<Emprunt>()
                .HasOne(e => e.Membre)
                .WithMany()
                .HasForeignKey(e => e.Id_Membre);
        }
    }
}
