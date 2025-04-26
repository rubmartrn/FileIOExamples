using Mediator;
using StudentApiForMediator.Requests;

namespace StudentApiForMediator.Handlers
{
    public class StudentFieldslValidationPipeLine : IPipelineBehavior<StudentAddRequest, StudentAddResponse>
    {
        public ValueTask<StudentAddResponse> Handle(StudentAddRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<StudentAddRequest, StudentAddResponse> next)
        {

            if (string.IsNullOrEmpty(message.Name))
            {
               return new ValueTask<StudentAddResponse>(new StudentAddResponse
               {
                   Success = false,
                   ErrorMessage = "Name is required"
               });
            }
            return next(message, cancellationToken);
        }
    }
}
