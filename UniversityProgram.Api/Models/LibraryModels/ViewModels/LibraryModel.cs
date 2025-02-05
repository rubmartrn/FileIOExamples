using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.StudentModels.ViewModels;

namespace UniversityProgram.Api.Models.LibraryModels.ViewModels
{
    public class LibraryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
