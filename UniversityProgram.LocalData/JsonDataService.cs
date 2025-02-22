using System.Text.Json;
using System.Threading.Tasks;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.LocalData
{
    public class JsonDataService : IJsonDataService
    {
        const string filePath = "./students.json";

        private List<Student> Students = new List<Student>();

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await ReadDataAsync<Student>();
            return Students;
        }

        private async Task WriteDataAsync<T>()
        {
            var students = await ReadDataAsync<Student>();
            Students.AddRange(students);
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                string json = JsonSerializer.Serialize(Students);
                await streamWriter.WriteAsync(json);
            }
        }

        private async Task<IEnumerable<T>> ReadDataAsync<T>()
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string json = await streamReader.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
        }

        public async Task SaveChangesAsync()
        {
            await WriteDataAsync<Student>();
        }
    }

    public interface IJsonDataService
    {
        void Add(Student student);
        Task<IEnumerable<Student>> GetStudents();
        Task SaveChangesAsync();
    }
}
