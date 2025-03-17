using Microsoft.AspNetCore.Mvc;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewTestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        { 
            await Test(token);

            return Ok();
        }

        private async Task<int> Test(CancellationToken token)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    
                }
                token.ThrowIfCancellationRequested();
                await Task.Delay(1000, token);
            }

            return 0;
        }
    }
}