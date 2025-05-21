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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id, CancellationToken token)
        {
            var user = await service.GetUserByIdAsync(id, token);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("pay/{id:int}")]
        public async Task<IActionResult> Pay([FromRoute] int id, [FromQuery] decimal money, CancellationToken token)
        {
            await service.Pay(id, money, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            await service.Delete(id, token);
          
            return Ok();
        }
    }
}
