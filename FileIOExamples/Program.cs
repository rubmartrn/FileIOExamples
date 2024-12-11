using System.Text;
using FileIOExamples;
using FileIOExamples.Business;

string fileName = "student.json";
string xmlFileName = "student.xml";
string binFileName = "student.bin";
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


Console.WriteLine("Ո՞ր բաժինն է պետք");
string option = Console.ReadLine();

if (option == "json")
{
    JsonHelper.Run(fileName, newFileName, student, students);
}

if (option == "xml")
{
    XmlHelper.Run(xmlFileName, newFileName, student, students);
}

if (option is "bin")
{
    BinaryHelper.Run(binFileName, newFileName, student, students);
}

//xml