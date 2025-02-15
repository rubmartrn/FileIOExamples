namespace UniversityProgram.BLL.Models
{
    public class StudentWithCourseModel : StudentModel
    {
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
