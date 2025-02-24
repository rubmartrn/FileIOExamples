using Microsoft.AspNetCore.Mvc;
using UniversityProgram.BLL.Models;
using UniversityProgram.BLL.Services;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ITestService _testService;

        public CoursesController(IUnitOfWork uow, ITestService testService)
        {
            _uow = uow;
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var name = _testService.Name;
            var age = _testService.Age;
            var @enum = _testService.TestEnum;
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
