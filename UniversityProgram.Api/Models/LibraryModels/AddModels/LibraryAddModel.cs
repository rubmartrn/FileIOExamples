using UniversityProgram.Api.Models.StudentModels.AddModels;

namespace UniversityProgram.Api.Models.LibraryModels.AddModels
{
    public class LibraryAddModel
    {
        public string? Name { get; set; }
        public ICollection<StudentAddModel> Students { get; set; } = new List<StudentAddModel>();
    }
}
