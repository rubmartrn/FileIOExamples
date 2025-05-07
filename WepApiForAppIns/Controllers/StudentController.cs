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
        private readonly HttpClient _client;

        public StudentController(IStudentService service, HttpClient client)
        {
            _service = service;
            _client = client;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello from StudentController" });
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
    }
}
