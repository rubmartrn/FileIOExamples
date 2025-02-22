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
            var students = ReadDataAsync<Student>().Result;
            var maxId = students.Max(s => s.Id);
            student.Id = maxId + 1;
            Students.Add(student);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await ReadDataAsync<Student>();
            return students;
        }

        private async Task WriteDataAsync<T>()
        {
            var students = await ReadDataAsync<Student>();
            Students.AddRange(students);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                string json = JsonSerializer.Serialize(Students);
                await streamWriter.WriteAsync(json);
            }
        }

        private async Task<IEnumerable<T>> ReadDataAsync<T>()
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
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
