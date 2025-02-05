namespace UniversityProgram.Api.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public decimal Fee { get; set; }

        public string? Paid { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
