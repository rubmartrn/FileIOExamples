using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;

namespace NewApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private static List<Student> students = new List<Student>
    {
        new Student{
            Id = 1,
            Name = "Petros",
            Address = "Gyumri",
            Type = StudentType.Type1,
            UniversityName = "YSU",
            Date = DateTime.Now
        },
        new Student{
            Id = 2,
            Name = "Poghos",
            Address = "Yerevan",
            Type = StudentType.Type2,
            UniversityName = "YSU",
            Date = DateTime.Now
        },
        new Student{
            Id = 3,
            Name = "Martiros",
            Address = "Ararat",
            Type = StudentType.Type3,
            UniversityName = "YSU",
            Date = DateTime.Now
        }
    };

    [HttpGet]
    public List<Student> Get()
    {
        return students;
    }

    [HttpGet("{id}")]
    public Student Get([FromRoute] int id)//path
    {
        return students.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public int Post([FromBody] Student student)//body
    {
        students.Add(student);
        return student.Id;
    }

    [HttpPut("{id}")]
    public Student Update([FromRoute] int id, [FromBody] StudentUpdateModel student)
    {
        var existingStudent = students.FirstOrDefault(x => x.Id == id);

        if (existingStudent != null)
        {
            existingStudent.Address = student.Address;
            existingStudent.Type = student.Type;
            existingStudent.UniversityName = student.UniversityName;
        }
        return existingStudent;
    }

    [HttpDelete("{id}")]
    public int Delete([FromRoute] int id)
    {
        var student = students.FirstOrDefault(x => x.Id == id);
        if (student != null)
        {
            students.Remove(student);
        }
        return id;
    }


    [HttpGet("filter")]
    public IEnumerable<Student> Filter([FromQuery] string name, [FromQuery] string address)
    {
        return students.Where(e =>
       (!string.IsNullOrEmpty(name) && e.Name.ToLower().Contains(name.ToLower()))
        || (!string.IsNullOrEmpty(address) && e.Address.ToLower().Contains(address.ToLower()))).ToList();
    }


    [HttpGet("Barev/Hajox")]
    public string Barev([FromHeader] string test)
    {
        return "Barev";
    }
}