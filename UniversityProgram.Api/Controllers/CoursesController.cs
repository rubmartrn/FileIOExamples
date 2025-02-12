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
        private readonly IUnitOfWork _uow;

        public CoursesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _uow.CourseRepository.GetCourses(token));
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseAddModel model, CancellationToken token)
        {
            var course = new Course()
            {
                Name = model.Name,
                Fee = model.Price
            };

            _uow.CourseRepository.AddCourse(course, token);
            await _uow.Save(token);
            return Ok();
        }

    }
}
