using UniversityProgram.Api.Models.StudentModels.ViewModels;

namespace UniversityProgram.Api.Models.UniversityModels.ViewModels
{
    public class UniversityModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
