using UniversityProgram.Api.Models.StudentModels.ViewModels;

namespace UniversityProgram.Api.Models.CourseModels.ViewModels
{
    public class CourseWithStudentsModel : CourseModel
    {
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
