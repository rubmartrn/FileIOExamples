using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;
using NewApi.Services;

namespace NewApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IStudentService _service;

    public TestController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet("Student")]
    public IActionResult GetStudent([FromQuery] string universityName)
    {
        var students = _service.GetAll();
        var result = Test1(students, universityName);
        var t = Test11(result);
        return Ok(
            new
            {
                t,
                count = t.Count
            });
    }

    private List<Student> Test1(List<Student> s, string universityName)
    {
        var result = new List<Student>();
        foreach (var student in s)
        {
            student.UniversityName = student.UniversityName.ToLower();
            if (student.UniversityName == universityName)
            {
                result.Add(student);
            }
        }
        return result;
    }

    private List<Student> Test11(List<Student> s)
    {
        var result = new List<Student>();
        foreach (var student in s)
        {
            if (student.Id < 1000)
            {
                result.Add(student);
            }
        }
        return result;
    }

    [HttpGet("Student2")]
    public IActionResult GetStudent2([FromQuery] string universityName)
    {
        var students = _service.GetAll();
        var result = Test2(students, universityName);
        var t = Test22(result);
        var tt = t.ToList();
        return Ok(new
        {
            tt,
            tt.Count
        });
    }

    private IEnumerable<Student> Test2(List<Student> s, string universityName)
    {
        foreach (var student in s)
        {
            student.UniversityName = student.UniversityName.ToLower();
            if (student.UniversityName == universityName)
            {
                yield return student;
            }
        }
    }

    private IEnumerable<Student> Test22(IEnumerable<Student> s)
    {
        foreach (var student in s)
        {
            if (student.Id < 1000)
            {
                yield return student;
            }
        }
    }

    [HttpGet("Content")]
    public ContentResult GetContent()
    {
        return new ContentResult
        {
            Content = "Hello World",
            StatusCode = 200
        };
    }

    [HttpGet("Json")]
    public JsonResult GetJson()
    {
        return new JsonResult(new
        {
            Name = "Petros",
            Age = 25,
            suihsdiufsdf = "sdfsd"
        });
    }

    [HttpGet("Redirect")]
    public RedirectResult GetRedirect()
    {
        return new RedirectResult("https://www.google.com");
    }
}