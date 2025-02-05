using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.CpuModels.UpdateModels;
using UniversityProgram.Api.Services.CpuService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CpusController : ControllerBase
    {
        private readonly ICpuService _cpuService;

        public CpusController(ICpuService cpuService)
        {
            _cpuService = cpuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _cpuService.GetAllAsync(token));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken token)
        {
            return Ok(await _cpuService.GetByIdAsync(id, token));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CpuAddModel model, [FromServices] IValidator<CpuAddModel> validator, CancellationToken token)
        {
            await _cpuService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            await _cpuService.DeleteAsync(id, token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CpuUpdateModel model, CancellationToken token)
        {
            await _cpuService.UpdateAsync(id, model, token);
            return Ok();
        }
    }
}
