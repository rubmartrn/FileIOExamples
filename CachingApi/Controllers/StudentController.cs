using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using UniversityProgram.BLL.Services;

namespace CachingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMemoryCache _cache;
        private const string Key = "students";

        public StudentController(IStudentService studentService, IMemoryCache cache)
        {
            _studentService = studentService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            if (_cache.TryGetValue<IEnumerable<UniversityProgram.BLL.Models.StudentModel>>(Key, out  var result))
            {
                return Ok(result);
            }
            IEnumerable<UniversityProgram.BLL.Models.StudentModel> students = await _studentService.GetAll(token);
            _cache.Set(Key, students, DateTimeOffset.Now.AddSeconds(600));
            return Ok(new { Message = "Hello from StudentController" });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken token)
        {
            string key = "students_" + id;
            if (_cache.TryGetValue<UniversityProgram.BLL.Models.StudentModel>(key, out var result))
            {
                return Ok(result);
            }
            var student =  await _studentService.GetById(id, token);
            if (student == null)
            {
                return NotFound();
            }
            _cache.Set(key, student, DateTimeOffset.Now.AddSeconds(600));
            return Ok(student);
        }

        [HttpGet("clear")]
        public IActionResult ClearCache()
        {
            _cache.Remove(Key);
            return Ok(new { Message = "Cache cleared" });
        }
    }
}
