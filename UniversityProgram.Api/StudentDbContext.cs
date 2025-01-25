using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(e => e.Id);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "Server=localhost;Database=UniversityProgram;User Id=sa;Password=Password123!;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}