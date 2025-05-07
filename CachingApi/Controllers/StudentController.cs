using Microsoft.AspNetCore.Mvc;
using UniversityProgram.BLL.Services;

namespace CachingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var students = await _studentService.GetAll(token);
            return Ok(new { Message = "Hello from StudentController" });
        }
    }
}
