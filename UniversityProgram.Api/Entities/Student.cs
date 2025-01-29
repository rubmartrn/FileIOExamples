namespace UniversityProgram.Api.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;

        public Laptop? Laptop { get; set; } = default!;

        public int? LibraryId { get; set; }
        public Library? Library { get; set; }

        public IEnumerable<University> Universities { get; set; } = new List<University>();
        public IEnumerable<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
