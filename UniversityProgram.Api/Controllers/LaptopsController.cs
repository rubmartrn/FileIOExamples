using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.UpdateModels;
using UniversityProgram.Api.Services.LaptopsService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopsController : ControllerBase
    {
        private readonly ILaptopsService _laptopsService;

        public LaptopsController(ILaptopsService laptopsService)
        {
            _laptopsService = laptopsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var laptops = await _laptopsService.GetAllAsync(token);
            return Ok(laptops);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LaptopAddModel model,
                                             [FromServices] IValidator<LaptopAddModel> validator,
                                             CancellationToken token)
        {
            await _laptopsService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpGet("{id}/cpu")]
        public async Task<IActionResult> GetCpu(int id, CancellationToken token)
        {
            return Ok(await _laptopsService.GetCpuAsync(id, token));
        }

        [HttpPut("{id}/cpu")]
        public async Task<IActionResult> AddCpu(int id, int cpuId, CancellationToken token)
        {
            await _laptopsService.AddCpuAsync(id, cpuId, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            await _laptopsService.DeleteAsync(id, token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LaptopUpdateModel model, CancellationToken token)
        {
            await _laptopsService.UpdateAsync(id, model, token);
            return Ok();
        }
    }
}