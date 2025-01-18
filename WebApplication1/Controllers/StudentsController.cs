using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;
using StudentUpdateModel = WebApplication1.Models.StudentUpdateModel;

namespace WebApplication1.Controllers;

[ApiController]
[Route("my/[controller]")]
public class StudentsController : ControllerBase
{

    private static List<Student> students = new List<Student>();

    [HttpPost]
    public void Create([FromBody] Student student)
    {
        students.Add(student);
    }

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return students;
    }

    [HttpGet("{id}")]
    public Student GetById([FromRoute] int id)
    {
        return students.First(e => e.Id == id);
    }

    [HttpPut("{id}")]
    public void Update([FromRoute] int id, [FromBody] StudentUpdateModel model)
    {
        var student = students.FirstOrDefault(e => e.Id == id);
        if (student is null)
        {
            throw new Exception($"{id} այդիով ուսանող չկա");
        }
        student.Name = model.Name;
        student.Address = model.Address;
        student.UniversityName = model.UniversityName;
    }

    [HttpDelete("id")]
    public void Delete(int id)
    {
        var student = students.FirstOrDefault(e => e.Id == id);
        if (student is null)
        {
            throw new Exception($"{id} այդիով ուսանող չկա");
        }

        students.Remove(student);
    }
}
