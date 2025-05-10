using BackGroundApi.Jobs;
using BackGroundApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackGroundApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateReport([FromServices] ReportService service)
        {
            await service.CreateAndSendReport(CancellationToken.None);
            return Ok();
        }  
        
        [HttpGet("job")]
        public Task<IActionResult> CreateReportJob([FromServices] ReportJob job)
        {
            job.Excecute(CancellationToken.None);
            return Task.FromResult<IActionResult>(Ok("Report job started.."));
        }
    }
}
