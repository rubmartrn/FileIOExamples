using UniversityProgram.Api.Models.CpuModels.ViewModels;

namespace UniversityProgram.Api.Models.LaptopModels.ViewModels
{
    public class LaptopModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public CpuModel? Cpu { get; set; } = default!;
    }
}
