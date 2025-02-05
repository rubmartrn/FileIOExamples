using System.ComponentModel.DataAnnotations;
using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Models.CourseModels.AddModels
{
    public class CourseAddModel
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "ինչ որ սխալ")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Գինը պարտադիր է")]
        [Range(1000, 2000, ErrorMessage = "Գինը պետք է լինի 1000-ից 2000 միջակայքում")]
        public decimal Fee { get; set; }

        public IEnumerable<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

    }
}
