using UniversityProgram.Api.Models.CpuModels.AddModels;

namespace UniversityProgram.Api.Models.LaptopModels.AddModels
{
    public class LaptopAddModel
    {
        public string Name { get; set; } = default!;

        public CpuAddModel? Cpu { get; set; }
    }
}
