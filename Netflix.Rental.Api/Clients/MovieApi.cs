using Netflix.Rental.Api.Models;

namespace Netflix.Rental.Api.Clients
{
    public class MovieApi(HttpClient client)
    {
        public async Task<MovieModel> GetMovieById(int id, CancellationToken token)
        {
            return await client.GetFromJsonAsync<MovieModel>($"api/movie/{id}", token);
        }

        public async Task RentMovie(int id, CancellationToken token)
        {
            await client.GetAsync($"api/movie/rent?movieId={id}", token);
        }
    }
}
