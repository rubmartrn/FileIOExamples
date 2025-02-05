using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.LibraryModels.AddModels;
using UniversityProgram.Api.Models.UpdateModels.LibraryModels;
using UniversityProgram.Api.Services.LibrariesService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryService _librariesService;

        public LibrariesController(ILibraryService librariesService)
        {
            _librariesService = librariesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _librariesService.GetAllAsync(token));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LibraryAddModel model, [FromServices] IValidator<LibraryAddModel> validator, CancellationToken token)
        {
            await _librariesService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken token)
        {
            return Ok(await _librariesService.GetByIdAsync(id, token));
        }

        [HttpPut("{id}/student")]
        public async Task<IActionResult> AddStudent(int id, [FromQuery] int studentId, CancellationToken token)
        {
            await _librariesService.AddStudentAsync(id, studentId, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            await _librariesService.DeleteAsync(id, token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LibraryUpdateModel model, CancellationToken token)
        {
            await _librariesService.UpdateAsync(id, model, token);
            return Ok();
        }
    }
}
