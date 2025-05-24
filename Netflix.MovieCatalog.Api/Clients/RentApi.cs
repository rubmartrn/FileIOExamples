namespace Netflix.MovieCatalog.Api.Clients
{
    public class RentApi(HttpClient httpClient)
    {
        public async Task<bool> DeleteRents(int movieId, CancellationToken token)
        {
            var response = await httpClient.DeleteAsync($"api/rental/movie/{movieId}", token);
            return response.IsSuccessStatusCode;
        }
    }
}
