using UniversityProgram.Api.Models.StudentModels.AddModels;

namespace UniversityProgram.Api.Models.UniversityModels.AddModels
{
    public class UniversityAddModel
    {
        public string? Name { get; set; }
        public IEnumerable<StudentAddModel> Students { get; set; } = new List<StudentAddModel>();
    }
}
