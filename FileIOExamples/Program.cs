using System.Text;
using FileIOExamples;
using FileIoExamples.Business;
using FileIOExamples.Business;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();

services.AddTransient<JsonHelper>();
services.AddTransient<XmlHelper>();
services.AddTransient<BinaryHelper>();
services.AddTransient<IOptionService, OptionService>();
services.AddSingleton<ITools, Tools>();
services.AddSingleton<IToolsOption, ToolsOption>();


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



var serviceProvider = services.BuildServiceProvider();

while (true)
{
    Console.WriteLine("Ո՞ր բաժինն է պետք");
    string option = Console.ReadLine();

    try
    {
        if (option == "json")
        {
            JsonHelper jsonHelper = serviceProvider.GetService<JsonHelper>()!;
            jsonHelper.Run($"{fileName}.json", null, student, new List<Student>());
        }

        if (option == "xml")
        {
            XmlHelper xmlHelper = serviceProvider.GetService<XmlHelper>()!;
            xmlHelper.Run($"{fileName}.xml", null, student, new List<Student>());
        }

        if (option is "bin")
        {
            BinaryHelper binaryHelper = serviceProvider.GetService<BinaryHelper>()!;
            binaryHelper.Run($"{fileName}.bin", null, student, new List<Student>());
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}
