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
            service.CreateAndSendReport(CancellationToken.None);
            return Ok();
        }  
        
        [HttpGet("job")]
        public Task<IActionResult> CreateReportJob([FromServices] ReportJob job)
        {
            if (job.InProgress)
            {
                return Task.FromResult<IActionResult>(BadRequest("Report job already in progress"));
            }
            job.Excecute(CancellationToken.None);
            return Task.FromResult<IActionResult>(Ok("Report job started.."));
        }
    }
}
