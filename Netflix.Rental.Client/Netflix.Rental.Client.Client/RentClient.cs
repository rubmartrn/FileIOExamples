public class RentClient(HttpClient client)
{
    public async Task DeleteRents(int userId, CancellationToken token)
    {
        await client.DeleteAsync($"api/rental/user/{userId}", token);
    }
}