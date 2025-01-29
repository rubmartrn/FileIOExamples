using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = default!;

        public DbSet<Laptop> Laptops { get; set; } = default!;

        public DbSet<Cpu> Cpus { get; set; } = default!;

        public DbSet<Library> Libraries { get; set; } = default!;

        public DbSet<University> Universities { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

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
            modelBuilder.Entity<Student>().HasIndex(e => e.Email).IsUnique();

            modelBuilder.Entity<Student>()
                .HasOne(e=>e.Laptop)
                .WithOne(e => e.Student)
                .HasForeignKey<Laptop>(e => e.StudentId);

            modelBuilder.Entity<Laptop>().HasKey(e => e.Id);
            modelBuilder.Entity<Laptop>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Cpu>().HasKey(e => e.Id);
            modelBuilder.Entity<Cpu>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Laptop>()
                .HasOne(e=>e.Cpu)
                .WithOne(e => e.Laptop)
                .HasForeignKey<Cpu>(e => e.LaptopId);

            modelBuilder.Entity<Library>().HasKey(e => e.Id);
            modelBuilder.Entity<Library>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasOne(e => e.Library)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.LibraryId);


            modelBuilder.Entity<University>().HasKey(e => e.Id);

            modelBuilder.Entity<University>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<University>().HasMany(e => e.Students)
                .WithMany(e => e.Universities);

            modelBuilder.Entity<Course>().HasKey(e => e.Id);

            modelBuilder.Entity<Course>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Course>().HasMany(e => e.CourseStudents).WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Student>().HasMany(e=>e.CourseStudents).WithOne().HasForeignKey(e => e.StudentId);

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