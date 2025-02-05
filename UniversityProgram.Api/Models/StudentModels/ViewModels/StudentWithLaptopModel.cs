using UniversityProgram.Api.Models.LaptopModels.ViewModels;

namespace UniversityProgram.Api.Models.StudentModels.ViewModels
{
    public class StudentWithLaptopModel : StudentModel
    {
        public LaptopWithCpuModel? Laptop { get; set; }
    }
}
