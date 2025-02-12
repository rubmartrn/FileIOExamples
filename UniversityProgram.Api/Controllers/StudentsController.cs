using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.AcaValidation;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models;
using UniversityProgram.Api.Repositories;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly ICourseRepository _courseRepository;

        public StudentsController(IStudentRepository repository, ICourseRepository courseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentAddModel model, CancellationToken token)
        {
            var validator = new AcaValidator(model);
            validator.AddRule(CheckEmailNotNull, "մեյլը պետք է արժեք ունենա");
            var result = await validator.Validate();
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessages);
            }

            var student = model.Map();

            await _repository.AddStudent(student, token);
            return Ok();

            bool CheckEmailNotNull(StudentAddModel model)
            {
                return model.Email is not null;
                //return model.Email != null;
                //return !string.IsNullOrEmpty(model.Email);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var students = await _repository.GetStudents(token);
            return Ok(students.Select(e => e.Map()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            var student = await _repository.GetStudentById(id, token);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.Map());
        }

        [HttpGet("{id}/laptop")]
        public async Task<IActionResult> GetByIdWithLaptop([FromRoute] int id, CancellationToken token)
        {
            var student = await _repository.GetByIdWithLaptop(id, token);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.MapToStudentWithLaptop());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentUpdateModel model, CancellationToken token)
        {
            var student = await _repository.GetStudentById(id, token);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = model.Name ?? student.Name;
            student.Email = model.Email is not null ? model.Email : student.Email;
            await _repository.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var student = await _repository.GetStudentById(id, token);
            if (student == null)
            {
                return NotFound();
            }
            await _repository.DeleteStudent(student, token);
            return Ok();
        }

        //[HttpGet("{id}/course")]
        //public async Task<IActionResult> GetWithCourses([FromRoute] int id, CancellationToken token)
        //{
        //    var student = await _ctx.Students
        //        .Include(e => e.CourseStudents)
        //        .ThenInclude(e => e.Course)
        //        .FirstOrDefaultAsync(e => e.Id == id, token);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(student.MapStudentWithCourseModel());
        //}

        //[HttpPut("{id}/addmoney")]
        //public async Task<IActionResult> AddMoney([FromRoute] int id, [FromQuery] decimal money, CancellationToken token)
        //{
        //    var student = await _ctx.Students.FirstOrDefaultAsync(e => e.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    student.Money += money;
        //    await _ctx.SaveChangesAsync(token);
        //    return Ok();
        //}

        [HttpPut("{id}/Pay/{courseId}")]
        public async Task<IActionResult> PayForCourse([FromRoute] int id,
            [FromRoute] int courseId)
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
            return Ok();
        }

        [HttpPut("{id}/course")]
        public async Task<IActionResult> AddCourse(int id, [FromQuery] int courseId, CancellationToken token)
        {
            var student = await _repository.GetStudentById(id, token);
            if (student == null)
            {
                return NotFound();
            }

            var course = await _courseRepository.GetCourseById(courseId, token);
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

            await _repository.UpdateStudent(student);

            return Ok();
        }
    }
}