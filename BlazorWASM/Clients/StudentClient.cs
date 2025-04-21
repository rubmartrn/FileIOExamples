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
            int count = 0;
            while (true)
            {

                try
                {
                    return await _client.GetFromJsonAsync<StudentModel>("Student/open");
                }
                catch (Exception)
                {
                    if (count <= 3)
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<StudentModel> Private()
        {
            return await _client.GetFromJsonAsync<StudentModel>("Student/private");
        }
    }
}
