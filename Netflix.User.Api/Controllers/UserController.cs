using Microsoft.AspNetCore.Mvc;
using Netflix.User.Api.Services;

namespace Netflix.User.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var users = await service.GetAllUsersAsync(token);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserManagement.Data.Entities.User user, CancellationToken token)
        {
            await service.Add(user, token);
            return Ok();
        }
    }
}
