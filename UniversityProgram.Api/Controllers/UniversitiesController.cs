using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.UniversityModels.AddModels;
using UniversityProgram.Api.Models.UniversityModels.UpdateModels;
using UniversityProgram.Api.Services.UniversitiesService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _universityService.GetAllAsync(token));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UniversityAddModel model, [FromServices] IValidator<UniversityAddModel> validator, CancellationToken token)
        {
            await _universityService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _universityService.GetByIdAsync(id, token));
        }

        [HttpPut("{id}/student")]
        public async Task<IActionResult> AddStudent([FromRoute] int id, [FromQuery] int studentId, CancellationToken token)
        {
            await _universityService.AddStudentAsync(id, studentId, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            await _universityService.DeleteAsync(id, token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UniversityUpdateModel model, CancellationToken token)
        {
            await _universityService.UpdateAsync(id, model, token);
            return Ok();
        }
    }

}
