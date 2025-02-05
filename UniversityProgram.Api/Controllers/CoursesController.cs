using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.CourseModels.AddModels;
using UniversityProgram.Api.Models.CourseModels.UpdateModels;
using UniversityProgram.Api.Services.CoursesService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService service)
        {
            _coursesService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _coursesService.GetAllAsync(token));
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CourseAddModel model, [FromServices] IValidator<CourseAddModel> validator, CancellationToken token)
        {
            await _coursesService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _coursesService.GetByIdAsync(id, token));
        }

        [HttpGet("{id}/Student")]
        public async Task<IActionResult> GetWithStudents([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _coursesService.GetWithStudentsAsync(id, token));
           
        }

        [HttpPut("{id}/Student")]
        public async Task<IActionResult> AddStudent(int id, [FromQuery] int courseId, CancellationToken token)
        {
            await _coursesService.AddStudentAsync(id, courseId, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            await _coursesService.DeleteAsync(id, token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CourseUpdateModel model, CancellationToken token)
        {
            await _coursesService.UpdateAsync(id, model, token);
            return Ok();
        }
    }
}
