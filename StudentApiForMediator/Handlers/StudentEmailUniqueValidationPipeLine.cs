using Mediator;
using StudentApiForMediator.Data;
using StudentApiForMediator.Requests;

namespace StudentApiForMediator.Handlers
{
    public class StudentEmailUniqueValidationPipeLine : IPipelineBehavior<StudentAddRequest, StudentAddResponse>
    {
        private readonly Database _database;

        public StudentEmailUniqueValidationPipeLine(Database database)
        {
            _database = database;
        }
        public ValueTask<StudentAddResponse> Handle(StudentAddRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<StudentAddRequest, StudentAddResponse> next)
        {

            var student = _database.Students.FirstOrDefault(x => x.Email == message.Email);
            if (student != null)
            {
                return new ValueTask<StudentAddResponse>(new StudentAddResponse
                {
                    Success = false,
                    ErrorMessage = "Email is not unique"
                });
            }

            return next(message, cancellationToken);
        }
    }
}
