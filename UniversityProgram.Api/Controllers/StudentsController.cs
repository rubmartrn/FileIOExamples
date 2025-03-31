using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UniversityProgram.Api.AcaValidation;
using UniversityProgram.Api.Hubs;
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
        private readonly IHubContext<StudentHub> _hub;

        public StudentsController(IStudentService service, IHubContext<StudentHub> hub)
        {
            _service = service;
            _hub = hub;
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

            await _hub.Clients.All.SendAsync("OnUpdate", $"ուսանողների ցանկը թարմացվեց");
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
            await Task.Delay(2000);
            return Ok(students);
            bool test = false;
            if (test)
            {
                return NotFound();
            }
            else
            {
                throw new Exception("սխալ գնաց մի բան");
            }
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

        [HttpGet("Query")]
        public async Task<IActionResult> GetByIdQuery([FromQuery] int id, [FromQuery] string name, [FromHeader] string test, CancellationToken token)
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
            await _hub.Clients.All.SendAsync("OnUpdate", $"ուսանողների ցանկը թարմացվեց");

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

            await _hub.Clients.All.SendAsync("OnUpdate", $" {id} այդիով Ուսանողը ջնջվեց");
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