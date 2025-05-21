using Netflix.MovieCatalog.Data.Entities;

namespace Netflix.MovieCatalog.Business
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync(CancellationToken token);
        Task Add(Movie movie, CancellationToken token);
        Task<Movie?> GetMovieByIdAsync(int id, CancellationToken token);
        Task RentMovie(int movieId, CancellationToken token);
    }
}
