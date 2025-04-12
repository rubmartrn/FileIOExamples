using Microsoft.EntityFrameworkCore;

namespace AuthTest.Api.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(e=>e.Email).IsUnique();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;

        public string? Role { get; set; }

        public string? PasswordHash { get; set; }
    }
}
