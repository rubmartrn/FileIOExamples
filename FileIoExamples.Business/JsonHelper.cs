using FileIOExamples.Business.Converters;
using System.Text.Json;

namespace FileIOExamples.Business
{
    public class JsonHelper
    {
        public static void Run(string fileName, string newFileName, Student student, IEnumerable<Student> students)
        {
            Console.WriteLine("Ի՞նչ անել");

            string option = Console.ReadLine();

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new StudentJsonConverter());

            if (option == "1")
            {
                string studentJson = JsonSerializer.Serialize(student, options);
                string j = JsonSerializer.Serialize(students);
                Tools.Write(j, newFileName);
                Tools.Write(studentJson, fileName);
            }
            else
            {
                string studentJ = Tools.Read(fileName);
                Student stud = JsonSerializer.Deserialize<Student>(studentJ, options);
                string json = Tools.Read(newFileName);
                List<Student> studentList = JsonSerializer.Deserialize<List<Student>>(json, options);
            }
        }
    }
}
