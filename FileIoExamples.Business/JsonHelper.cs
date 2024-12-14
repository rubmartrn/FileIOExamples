using FileIoExamples.Business;
using FileIOExamples.Business.Converters;
using System.Text.Json;

namespace FileIOExamples.Business
{
    public class JsonHelper
    {
        private readonly IOptionService _optionService;
        private readonly ITools _tools;

        public JsonHelper(IOptionService optionService, ITools tools)
        {
            _optionService = optionService;
            _tools = tools;
        }
        public void Run(string fileName, string newFileName, Student student, IEnumerable<Student> students)
        {
            string option = _optionService.GetSelectedOption();
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new StudentJsonConverter());

            if (option == "1")
            {
                string studentJson = JsonSerializer.Serialize(student, options);
                string j = JsonSerializer.Serialize(students);
                _tools.Write(j, newFileName);
                _tools.Write(studentJson, fileName);
            }
            else
            {
                string studentJ = _tools.Read(fileName);
                Student stud = JsonSerializer.Deserialize<Student>(studentJ, options);
                string json = _tools.Read(newFileName);
                List<Student> studentList = JsonSerializer.Deserialize<List<Student>>(json, options);
            }
        }
    }
}
