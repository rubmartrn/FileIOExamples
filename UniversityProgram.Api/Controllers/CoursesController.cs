using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly StudentDbContext ctx;

        public CoursesController(StudentDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await ctx.Courses.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseAddModel model)
        {
            var course = new Course()
            {
                Name = model.Name
            };

            ctx.Courses.Add(course);
            await ctx.SaveChangesAsync();
            return Ok();
        }

    }
}
