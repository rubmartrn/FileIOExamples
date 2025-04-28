using Microsoft.AspNetCore.Mvc;

namespace WebApiForLogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.Log(LogLevel.Information, "Get method called");
            return Ok(new { Message = "Hello from CourseController" });
        }
    }
}
