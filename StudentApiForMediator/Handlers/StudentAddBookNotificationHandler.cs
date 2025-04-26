using Mediator;
using StudentApiForMediator.Notifications;
using StudentApiForMediator.Services;

namespace StudentApiForMediator.Handlers
{
    public class StudentAddBookNotificationHandler : INotificationHandler<StudentAddedNotification>
    {
        private readonly BookService _service;

        public StudentAddBookNotificationHandler(BookService service)
        {
            _service = service;
        }
        public ValueTask Handle(StudentAddedNotification notification, CancellationToken cancellationToken)
        {
            _service.AddBook(notification.BookId, notification.StudentId);
            return ValueTask.CompletedTask;
        }
    } 
}
