using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        [HttpGet("login")]
        public string Login([FromServices] TokenGenerator generator)
        {
            return generator.Generate("ruben@gmail.com", "admin");
        }
    }
}
