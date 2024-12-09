using System.Text;
using FileIOExamples;
using System.Text.Json;
using FileIOExamples.Converters;

string fileName = "student.json";
string newFileName = "students.json";
Console.OutputEncoding = Encoding.UTF8;

if (!File.Exists(fileName))
{
    using (FileStream f = File.Create(fileName))
    {
    }
}

if (!File.Exists(newFileName))
{
    using (FileStream f = File.Create(newFileName))
    {
    }
}
List<Student> students = new List<Student>()
{
    new Student()
    {
        Id = 7,
        Name = "Poghos",
        Address = "Yerevan",
        UniversityName = "University",
        Type = StudentType.Type1,
        Date = DateTime.Now

    },
    new Student()
    {
        Id = 7,
        Name = "Petros",
        Address = "Yerevan",
        UniversityName = "University",
        Type = StudentType.Type3,
        Date = DateTime.Now
    },
    new Student()
    {
        Id = 7,
        Name = "Martiros",
        Address = "Yerevan",
        UniversityName = "University",
        Type = StudentType.Type2,
        Date = DateTime.Now
    },
    new Student()
    {
        Id = 7,
        Name = "John",
        Address = "Yerevan",
        Type = StudentType.Type1,
        Date = DateTime.Now
    },
};

Student student = new Student()
{
    Id = 7,
    Name = "Poghos",
    Address = "Yerevan",
    UniversityName = "University"
};

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