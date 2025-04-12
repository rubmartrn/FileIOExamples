using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NewAuthTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task Login([FromBody] UserModel model, [FromServices] SignInManager<IdentityUser> mng)
        {
            var result = await mng.PasswordSignInAsync(model.Email, model.Password, false, false);

            Console.WriteLine(User);
        }
    }

    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
