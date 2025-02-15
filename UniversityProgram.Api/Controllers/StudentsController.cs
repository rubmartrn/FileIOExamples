using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.AcaValidation;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Exceptions;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models;
using UniversityProgram.Api.Repositories;
using UniversityProgram.Api.Services;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
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

            await _service.Add(model, token);

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
            var students = await _service.GetAll(token);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            var student = await _service.GetById(id, token);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{id}/laptop")]
        public async Task<IActionResult> GetByIdWithLaptop([FromRoute] int id, CancellationToken token)
        {
            var student = await _service.GetByIdWithLaptop(id, token);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentUpdateModel model, CancellationToken token)
        {
            try
            {
                await _service.Update(id, model, token);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var result = await _service.Delete(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                {
                    return NotFound();
                }
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}/course")]
        public async Task<IActionResult> GetWithCourses([FromRoute] int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdWithCourse(id, token);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.MapStudentWithCourseModel());
        }

        [HttpPut("{id}/addmoney")]
        public async Task<IActionResult> AddMoney([FromRoute] int id, [FromQuery] decimal money, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            if (student == null)
            {
                return NotFound();
            }
            student.Money += money;

            _uow.StudentRepository.UpdateStudent(student);
            await _uow.Save(token);

            return Ok();
        }

        [HttpPut("{id}/Pay/{courseId}")]
        public async Task<IActionResult> PayForCourse([FromRoute] int id,
            [FromRoute] int courseId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            if (student == null)
            {
                return NotFound();
            }

            var courseStudent = await _uow.CourseStudentRepository.GetById(id, courseId, token);
            if (courseStudent == null)
            {
                return NotFound();
            }

            if (student.Money < courseStudent.Course.Fee)
            {
                return BadRequest("բավարար գումար չունի");
            }

            student.Money -= courseStudent.Course.Fee;
            _uow.StudentRepository.UpdateStudent(student);

            courseStudent.Paid = true;
            _uow.CourseStudentRepository.Update(courseStudent);
            await _uow.Save(token);

            return Ok();
        }

        [HttpPut("{id}/course")]
        public async Task<IActionResult> AddCourse(int id, [FromQuery] int courseId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            if (student == null)
            {
                return NotFound();
            }

            var course = await _uow.CourseRepository.GetCourseById(courseId, token);
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

            _uow.StudentRepository.UpdateStudent(student);
            await _uow.Save(token);

            return Ok();
        }
    }
}