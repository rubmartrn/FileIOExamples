using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.StudentModels.AddModels;
using UniversityProgram.Api.Models.StudentModels.UpdateModels;
using UniversityProgram.Api.Services.CourseBankService.Impl;
using UniversityProgram.Api.Services.StudentsService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentAddModel model, [FromServices] IValidator<StudentAddModel> validator, CancellationToken token)
        {
            await _studentsService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await _studentsService.GetAllAsync(token);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _studentsService.GetByIdAsync(id, token));
        }

        [HttpGet("{id}/laptop")]
        public async Task<IActionResult> GetWithLaptop([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _studentsService.GetByIdWithLaptopAsync(id, token));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentUpdateModel model, CancellationToken token)
        {
            await _studentsService.UpdateAsync(id, model, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            await _studentsService.DeleteAsync(id, token);
            return Ok();
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetWithCourses([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _studentsService.GetWithCoursesAsync(id, token));
        }

        [HttpGet("{id}/address")]
        public async Task<IActionResult> GetWithAddress([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _studentsService.GetByIdWithAddressAsync(id, token));
        }

        [HttpPut("{id}/money/add")]
        public async Task<IActionResult> AddMoney([FromRoute] int id, [FromQuery] decimal money, CancellationToken token)
        {
            await _studentsService.AddMoneyAsync(id, money, token);
            return Ok();
        }

        [HttpPut("{id}/course/{courseId}/pay")]
        public async Task<IActionResult> PayForCourse([FromRoute] int id, [FromRoute] int courseId, [FromServices] CourseBankServiceApi bankApi, CancellationToken token)
        {
            await _studentsService.PayForCourseAsync(id, courseId, bankApi, token);
            return Ok();
        }

        [HttpPut("{id}/course/{courseId}")]
        public async Task<IActionResult> AddCourse([FromRoute] int id, [FromRoute] int courseId, CancellationToken token)
        {
            await _studentsService.AddCourseAsync(id, courseId, token);
            return Ok();
        }
    }

}