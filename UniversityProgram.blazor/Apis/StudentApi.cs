using System.Net.Http.Json;
using UniversityProgram.blazor.Models;

namespace UniversityProgram.blazor.Apis
{
    public class StudentApi : IStudentApi
    {
        private readonly HttpClient _client;

        public StudentApi(HttpClient client)
        {
            _client = client;
        }

        public async Task<StudentModel> GetById(int id)
        {
            var response = await _client.GetAsync($"/Students/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StudentModel>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            var response = await _client.GetAsync("/Students");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<StudentModel>>();
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Error " + response.ReasonPhrase);
                return Array.Empty<StudentModel>();
            }
            else
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task Delete(int Id)
        {
            var response = await _client.DeleteAsync($"/Students/{Id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
