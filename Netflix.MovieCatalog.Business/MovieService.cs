using Microsoft.EntityFrameworkCore;
using Netflix.MovieCatalog.Data;
using Netflix.MovieCatalog.Data.Entities;

namespace Netflix.MovieCatalog.Business
{
    public class MovieService(MovieDbContext context) : IMovieService
    {

        public async Task<List<Movie>> GetAllMoviesAsync(CancellationToken token)
        {
            return await context.Movies.ToListAsync(token);
        }

        public async Task Add(Movie movie, CancellationToken token)
        {
            await context.Movies.AddAsync(movie, token);
            await context.SaveChangesAsync(token);
        }

        public async Task<Movie?> GetMovieByIdAsync(int id, CancellationToken token)
        {
            return await context.Movies.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task RentMovie(int movieId, CancellationToken token)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(e => e.Id == movieId, token);
            if (movie == null)
            {
                throw new Exception($"Movie with ID {movieId} not found.");
            }
            movie.Amount -= 1;
            if (movie.Amount < 0)
            {
                throw new Exception($"Movie with ID {movieId} is not available for rent.");
            }
            context.Movies.Update(movie);
            await context.SaveChangesAsync(token);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(e => e.Id == id, token);
            if (movie == null)
            {
                throw new Exception($"Movie with ID {id} not found.");
            }
            context.Movies.Remove(movie);
            var outbox = new OutBox
            {
                Type = Data.Enums.OutBoxType.MovieDeleted,
                Data = movie.Id.ToString(),
                CreatedAt = DateTime.UtcNow,
            };
            context.OutBoxes.Add(outbox);
            await context.SaveChangesAsync(token);
        }
    }
}
