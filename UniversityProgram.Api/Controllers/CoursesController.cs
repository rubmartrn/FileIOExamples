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
        private readonly Func<string, ITestService> _testServices;

        public CoursesController(IUnitOfWork uow, Func<string, ITestService> testServices)
        {
            _uow = uow;
            _testServices = testServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string serviceName ,CancellationToken token)
        {
            var testService = _testServices(serviceName);

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
