using BlazorWASM.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorWASM.Clients
{
    public class StudentClient
    {
        private readonly HttpClient _client;

        public StudentClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<StudentModel> Open()
        {
            return await _client.GetFromJsonAsync<StudentModel>("Student/open");
        }

        public async Task<StudentModel> Private()
        {
            return await _client.GetFromJsonAsync<StudentModel>("Student/private");
        }
    }
}
