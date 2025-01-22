using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Student>().Property(e => e.Name).IsRequired();
        }
    }
}
