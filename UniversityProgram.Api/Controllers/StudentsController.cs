using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.AcaValidation;
using UniversityProgram.Api.Map;
using UniversityProgram.BLL.Exceptions;
using UniversityProgram.BLL.Models;
using UniversityProgram.BLL.Services;

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
            return Ok(students);
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
            var result = await _service.GetByIdWithLaptop(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                {
                    return NotFound();
                }
                if (result.ErrorType == ErrorType.LaptopNotFound)
                {
                    return BadRequest($"{id} այդիով ուսանողը չունի սարք");
                }
            }

            return Ok(result.Data);
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
            var result = await _service.GetWithCourses(id, token);

            if (result.ErrorType == ErrorType.NotFound)
            {
                return NotFound();
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}/addmoney")]
        public async Task<IActionResult> AddMoney([FromRoute] int id, [FromQuery] decimal money, CancellationToken token)
        {
            var result = await _service.AddMoney(id, money, token);

            if (result.ErrorType == ErrorType.NotFound)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}/Pay/{courseId}")]
        public async Task<IActionResult> PayForCourse([FromRoute] int id,
            [FromRoute] int courseId, CancellationToken token)
        {
           

            return Ok();
        }

        [HttpPut("{id}/course")]
        public async Task<IActionResult> AddCourse(int id, [FromQuery] int courseId, CancellationToken token)
        {
            var result = await _service.Pay(id, courseId, token);

            if (result.ErrorType == ErrorType.NotFound)
            {
                return NotFound();
            }

            if (result.ErrorType == ErrorType.CommonError)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}