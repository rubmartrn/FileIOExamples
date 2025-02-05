using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Models.LaptopModels.UpdateModels
{
    public class LaptopUpdateModel
    {
        public string Name { get; set; } = default!;
        public Cpu Cpu { get; set; } = default!;
    }
}
