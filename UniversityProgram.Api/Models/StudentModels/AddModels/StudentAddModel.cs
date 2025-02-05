using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.AddressModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.AddModels;

namespace UniversityProgram.Api.Models.StudentModels.AddModels
{
    public class StudentAddModel
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public LaptopAddModel? Laptop { get; set; }

        public AddressAddModel? Address { get; set; }
    }
}
