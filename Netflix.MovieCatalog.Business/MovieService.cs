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
    }
}
