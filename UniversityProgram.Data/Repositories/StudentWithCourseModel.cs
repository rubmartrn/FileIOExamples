namespace UniversityProgram.BLL.Models
{
    public class StudentWithCourseModel : StudentModelData
    {
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }  
    public class StudentWithCourseModel1 : StudentModel1
    {
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
    public class StudentModelData
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public decimal Money { get; set; }
    }

    public class StudentModel1
    {
        public string Name { get; set; } = default!;
        public decimal Money { get; set; }
    }
}
