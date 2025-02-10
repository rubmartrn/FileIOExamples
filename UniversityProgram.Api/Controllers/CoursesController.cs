using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;
using UniversityProgram.Api.Repositories;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repository;

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _repository.GetCourses(token));
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseAddModel model, CancellationToken token)
        {
            var course = new Course()
            {
                Name = model.Name,
                Fee = model.Price
            };

            await _repository.AddCourse(course, token);
            return Ok();
        }

    }
}
