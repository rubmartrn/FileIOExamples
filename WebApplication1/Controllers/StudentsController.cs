using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("my/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public int Get()
    {
        return 42;
    }

    [HttpPost]
    public string Post([FromBody] Student s)
    {
        return $"Ձեր ուսանողի անունը {s.Name} է";
    }


    [HttpGet("test/{a}")]
    public void Test([FromRoute] string a)
    {
        Console.WriteLine("Test");
    }

    [HttpGet("new")]
    public string NewTest([FromQuery] string? p, [FromQuery] int? a)
    {
        return $"your param is {p}, a is {a}";
    }
}
