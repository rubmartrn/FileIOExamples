using Mediator;
using StudentApiForMediator.Data;
using StudentApiForMediator.Models;
using StudentApiForMediator.Requests;

namespace StudentApiForMediator.Services
{
    public class StudentHandler : IRequestHandler<StudentAddRequest, StudentAddResponse>
    {
        private readonly Database _database;

        public StudentHandler(Database database)
        {
            _database = database;
        }

        public ValueTask<StudentAddResponse> Handle(StudentAddRequest request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Id = request.Id,
                Email = request.Email,
            };
            _database.Students.Add(student);

            var response = new StudentAddResponse
            {
                Id = student.Id,
                Success = true
            };

            return ValueTask.FromResult(response);
        }
    }
}
