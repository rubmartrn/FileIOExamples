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

        [HttpGet("External")]
        public async Task<IActionResult> GetExternal()
        {
            var students = await _client.GetAsync("http://localhost:5260/Students");
            return Ok(students);
        }

        [HttpGet("google")]
        public async Task<IActionResult> GetGoogle()
        {
            var response = await _client.GetAsync("https://www.google.com");
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}
