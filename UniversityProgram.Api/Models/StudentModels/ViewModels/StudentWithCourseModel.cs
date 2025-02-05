using UniversityProgram.Api.Models.CourseModels.ViewModels;

namespace UniversityProgram.Api.Models.StudentModels.ViewModels
{
    public class StudentWithCourseModel : StudentModel
    {
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
