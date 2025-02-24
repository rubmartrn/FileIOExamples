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
        private readonly Dictionary<string, ITestService> _testServices;

        public CoursesController(IUnitOfWork uow, IEnumerable<ITestService> testServices)
        {
            _uow = uow;
            _testServices = testServices.ToDictionary(e=>e.GetType().Name, e=>e);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var testService = _testServices[nameof(TestService3)];

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
