using Mediator;

namespace StudentApiForMediator.Notifications
{
    public class StudentAddedNotification : INotification
    {
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public int CourseId { get; set; }
    }
}
