using Microsoft.AspNetCore.Mvc;

namespace WepApiForAppIns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
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
    }
}
