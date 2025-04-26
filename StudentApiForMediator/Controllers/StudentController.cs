using Mediator;
using Microsoft.AspNetCore.Mvc;
using StudentApiForMediator.Data;
using StudentApiForMediator.Models;
using StudentApiForMediator.Notifications;
using StudentApiForMediator.Requests;
using System.Threading.Tasks;

namespace StudentApiForMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentAddModel model)
        {
            var request = new StudentAddRequest(model.Id, model.Name, model.Email);

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                return BadRequest(response.ErrorMessage);
            }

            var notification = new StudentAddedNotification
            {
                StudentId = response.Id,
                BookId = model.BookId,
                CourseId = model.CourseId
            };

            await _mediator.Publish(notification);

            return Ok();
        }

        [HttpGet]
        public void Test([FromServices] Database database)
        {
            var books = database.Books.ToList();
            var courses = database.Courses.ToList();
            var students = database.Students.ToList();
            Console.WriteLine();
        }
    }
}
