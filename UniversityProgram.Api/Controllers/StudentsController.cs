using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models;
using UniversityProgram.Api.Services;

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
            var student = model.Map();

            _ctx.Students.Add(student);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _ctx.Students.ToListAsync();
            return Ok(students.Select(e => e.Map()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.Map());
        }

        [HttpGet("{id}/laptop")]
        public async Task<IActionResult> GetByIdWithLaptop([FromRoute] int id)
        {
            var student = await _ctx.Students
                .Include(e => e.Laptop)
                .ThenInclude(e => e.Cpu)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.MapToStudentWithLaptop());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentUpdateModel model, CancellationToken token)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id, token);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = model.Name ?? student.Name;
            student.Email = model.Email is not null ? model.Email : student.Email;
            _ctx.Students.Update(student);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id, token);
            if (student == null)
            {
                return NotFound();
            }
            _ctx.Students.Remove(student);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpGet("{id}/course")]
        public async Task<IActionResult> GetWithCourses([FromRoute] int id)
        {
            var student = await _ctx.Students
                .Include(e => e.CourseStudents)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.MapStudentWithCourseModel());
        }

        [HttpPut("{id}/addmoney")]
        public async Task<IActionResult> AddMoney([FromRoute] int id, [FromQuery] decimal money)
        {
            var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            student.Money += money;
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}/Pay/{courseId}")]
        public async Task<IActionResult> PayForCourse([FromRoute] int id,
            [FromRoute] int courseId,
            [FromServices] CourseBankServiceApi bankApi)
        {
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                var student = await _ctx.Students
                    .Include(e => e.CourseStudents)
                    .ThenInclude(e => e.Course)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                var courseStudent = student.CourseStudents.FirstOrDefault(e => e.CourseId == courseId);
                if (courseStudent == null)
                {
                    return NotFound();
                }

                if (student.Money < courseStudent.Course.Fee)
                {
                    return BadRequest("բավարար գումար չունի");
                }

                student.Money -= courseStudent.Course.Fee;
                courseStudent.Paid = true;
                await _ctx.SaveChangesAsync();
                bankApi.PayCourse(student.Id);
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut("{id}/course")]
        public IActionResult AddCourse(int id, [FromQuery] int courseId)
        {
            var student = _ctx.Students.FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            var course = _ctx.Courses.FirstOrDefault(e => e.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }

            var courseStudent = new CourseStudent()
            {
                Course = course,
                Student = student
            };

            student.CourseStudents.Add(courseStudent);

            _ctx.SaveChanges();

            return Ok();
        }
    }
}