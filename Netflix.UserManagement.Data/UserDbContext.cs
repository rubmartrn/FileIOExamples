using Microsoft.EntityFrameworkCore;
using Netflix.UserManagement.Data.Entities;

namespace Netflix.UserManagement.Data
{
    public class UserDbContext :DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
