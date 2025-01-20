using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bibliotech.Models
{
    public class BibliotechDb : DbContext
    {
        public DbSet<Livre> Livres { get; set; }
        
        public BibliotechDb(DbContextOptions<BibliotechDb> options)
            : base(options)
        {

        }
    }
}