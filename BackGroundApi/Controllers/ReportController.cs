using BackGroundApi.Data;
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
        [HttpGet("last")]
        public async Task<IActionResult> GetLastReport()
        {
            var lastReport = Database.Reports.OrderBy(e=>e.UpdatedAt).Last();
            return Ok(lastReport);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReport([FromServices] ReportService service)
        {
            service.CreateAndSendReport(CancellationToken.None);
            return Ok();
        }  
        
        [HttpGet("job")]
        public Task<IActionResult> CreateReportJob([FromServices] ReportJob job)
        {
            if (job.Progress != Enums.ProgressEnum.Ready)
            {
                return Task.FromResult<IActionResult>(BadRequest("Report job already in progress"));
            }
            job.Excecute(CancellationToken.None);
            return Task.FromResult<IActionResult>(Ok("Report job started.."));
        }

        [HttpGet("job/progress")]
        public Task<IActionResult> GetReportJobProgress([FromServices] ReportJob job)
        {
            return Task.FromResult<IActionResult>(Ok(job.Progress));
        }
    }
}
