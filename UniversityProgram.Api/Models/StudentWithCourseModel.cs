namespace UniversityProgram.Api.Models
{
    public class StudentWithCourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;

        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
