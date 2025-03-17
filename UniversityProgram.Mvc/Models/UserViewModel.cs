using System.ComponentModel.DataAnnotations;

namespace UniversityProgram.Mvc.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ImageUrl { get; set; }
    }
}
