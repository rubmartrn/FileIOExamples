using Microsoft.AspNetCore.Mvc;

namespace WebApiForLogs.Controllers.First
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get method called");
            return Ok(new { Message = "Hello from StudentController" });
        } 
        
        [HttpDelete]
        public IActionResult Delete()
        {
            _logger.LogWarning("Delete method called");
            return Ok(new { Message = "Hello from StudentController" });
        }

        [HttpPost]
        public IActionResult Post()
        {
            _logger.LogError("Delete method called");
            return Ok(new { Message = "Hello from StudentController" });
        }
    }
}
