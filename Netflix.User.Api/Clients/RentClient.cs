namespace Netflix.User.Api.Clients
{
    public class RentClient(HttpClient client)
    {
        public async Task<bool> DeleteRents(int userId, CancellationToken token)
        {
            var response = await client.DeleteAsync($"api/rental/user/{userId}", token);
            return response.IsSuccessStatusCode;
        }
    }
}
