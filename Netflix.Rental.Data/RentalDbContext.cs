using Microsoft.EntityFrameworkCore;
using Netflix.Rental.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Rental.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Rental>().ToTable("Rentals");
            modelBuilder.Entity<Entities.Rental>().HasKey(r => r.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
