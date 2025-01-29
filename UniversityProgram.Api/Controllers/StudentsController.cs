using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _ctx.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            var model = new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return Ok(model);
        }

        [HttpGet("{id}/laptop")]
        public async Task<IActionResult> GetByIdWithLaptop([FromRoute] int id)
        {
            var student = await _ctx.Students
                .Include(e => e.Laptop)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            var model = new StudentWithLaptopModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Laptop = student.Laptop is not null
                                ? new LaptopModel
                                {
                                    Id = student.Laptop.Id,
                                    Name = student.Laptop.Name
                                }
                                : null
            };

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentUpdateModel model)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = model.Name ?? student.Name;
            student.Email = model.Email is not null ? model.Email : student.Email;
            _ctx.Students.Update(student);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _ctx.Students.Remove(student);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}