using System.ComponentModel.DataAnnotations;

namespace UniversityProgram.Api.Models
{
    public class CourseAddModel
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "ինչ որ սխալ")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Գինը պարտադիր է")]
        [Range(1000, 2000, ErrorMessage = "Գինը պետք է լինի 1000-ից 2000 միջակայքում")]
        public decimal Price { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
