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
            throw new ArgumentOutOfRangeException(nameof(Get));
        }
    }
}
