namespace UniversityProgram.Api.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public IEnumerable<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
