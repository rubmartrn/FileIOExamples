using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        [HttpGet("login")]
        public IActionResult Login([FromServices] TokenGenerator generator)
        {
            var token = generator.Generate("ruben@gmail.com", "admin");
            
            var accessToken = Save(token);
            return Redirect($"http://localhost:5125/user/login?token={accessToken}");
        }

        public string Save(string token)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
