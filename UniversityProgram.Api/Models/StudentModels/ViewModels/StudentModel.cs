namespace UniversityProgram.Api.Models.StudentModels.ViewModels
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public decimal Money { get; set; }
    }
}
