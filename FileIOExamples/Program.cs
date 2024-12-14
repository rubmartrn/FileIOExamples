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

OptionService optionService = new OptionService();
Tools tools = new Tools(new ToolsOption());

if (option == "json")
{
    JsonHelper jsonHelper = new JsonHelper(optionService, tools);
    jsonHelper.Run($"{fileName}.json", null, student, new List<Student>());
}

if (option == "xml")
{
    XmlHelper xmlHelper = new XmlHelper(optionService, tools);
    xmlHelper.Run($"{fileName}.xml", null, student, new List<Student>());
}

if (option is "bin")
{
    BinaryHelper binaryHelper = new BinaryHelper(new OptionService());
    binaryHelper.Run($"{fileName}.bin", null, student, new List<Student>());
}

//xml