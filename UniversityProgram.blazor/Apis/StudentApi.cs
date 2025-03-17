using System.Net.Http.Json;
using UniversityProgram.blazor.Models;
using static System.Net.WebRequestMethods;

namespace UniversityProgram.blazor.Apis
{
    public class StudentApi : IStudentApi
    {
        private readonly HttpClient _client;

        public StudentApi(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
           return await _client.GetFromJsonAsync<List<StudentModel>>("/Students");
        }
    }
    public interface IStudentApi
    {
        Task<IEnumerable<StudentModel>> GetAll();
    }
}
