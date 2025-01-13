using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;
using NewApi.Services;

namespace NewApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    [HttpGet]
    public List<Student> Get([FromServices] IStudentService service)
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id, [FromServices] IStudentService service)//path
    {
        var student = service.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(student);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Student student, [FromServices] IStudentService service)//body
    {
        service.Add(student);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] StudentUpdateModel student, [FromServices] IStudentService service)
    {
        service.Update(id, student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id, [FromServices] IStudentService service)
    {
        service.Delete(id);
        return Ok();
    }

    [HttpGet("filter")]
    public IEnumerable<Student> Filter([FromQuery] string name, [FromQuery] string address, [FromServices] IStudentService service)
    {
        return service.Filter(name, address);
    }

    [HttpGet("Barev/Hajox")]
    public string Barev([FromHeader] string test)
    {
        return "Barev";
    }
}