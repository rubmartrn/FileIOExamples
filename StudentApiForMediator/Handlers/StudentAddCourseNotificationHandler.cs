using Mediator;
using StudentApiForMediator.Notifications;
using StudentApiForMediator.Services;

namespace StudentApiForMediator.Handlers
{
    public class StudentAddCourseNotificationHandler : INotificationHandler<StudentAddedNotification>
    {
        private readonly CourseService _courseService;

        public StudentAddCourseNotificationHandler(CourseService courseService)
        {
            _courseService = courseService;
        }

        public ValueTask Handle(StudentAddedNotification notification, CancellationToken cancellationToken)
        {
            _courseService.AddCourse(notification.CourseId, notification.StudentId);
            return ValueTask.CompletedTask;
        }
    }
}
