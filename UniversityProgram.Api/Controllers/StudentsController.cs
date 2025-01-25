using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _ctx;

        public StudentsController(StudentDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentAddModel model)
        {
            var student = new Student
            {
                Name = model.Name,
                Email = model.Email
            };

            _ctx.Students.Add(student);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}