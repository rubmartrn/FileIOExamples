using Netflix.Rental.Api.Models;

namespace Netflix.Rental.Api.Clients
{
    public class UserApi(HttpClient httpClient)
    {
        public async Task<UserModel> GetById(int userId, CancellationToken token)
        {
            return await httpClient.GetFromJsonAsync<UserModel>($"api/user/{userId}", token);
        }

        public async Task Pay(int userId, decimal money, CancellationToken token)
        {
            var response = await httpClient.GetAsync($"api/user/pay/{userId}?money={money}", token);
            response.EnsureSuccessStatusCode();
        }
    }
}
