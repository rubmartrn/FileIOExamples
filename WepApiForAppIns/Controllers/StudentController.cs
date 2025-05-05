using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProgram.BLL.Models;
using UniversityProgram.BLL.Services;

namespace WepApiForAppIns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello from StudentController" });
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new ArgumentOutOfRangeException(nameof(Error));
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetStudents(CancellationToken token)
        {
            var students = await _service.GetAll(token);
            return Ok(students);
        }

        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudentById(int id, CancellationToken token)
        {
            var student = await _service.GetById(id, token);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("students")]
        public async Task<IActionResult> AddStudent([FromBody] StudentAddModel model, CancellationToken token)
        {
            await _service.Add(model, token);
            return Ok();
        }
    }
}
