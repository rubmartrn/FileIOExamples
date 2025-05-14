using Microsoft.EntityFrameworkCore;

namespace Netflix.MovieCatalog.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Entities.Movie> Movies { get; set; } = default!;
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Movie>().ToTable("Movies");
            modelBuilder.Entity<Entities.Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Entities.Movie>().Property(m => m.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Entities.Movie>().Property(m => m.Amount).IsRequired();
            modelBuilder.Entity<Entities.Movie>().Property(m => m.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
