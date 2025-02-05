using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.CpuModels.ViewModels;

namespace UniversityProgram.Api.Map
{
    public static class CpuMap
    {
        public static Cpu Map(this CpuAddModel model)
        {
            return new Cpu
            {
                Name = model.Name
            };
        }

        public static CpuModel Map(this Cpu cpu)
        {
            return new CpuModel
            {
                Id = cpu.Id,
                Name = cpu.Name
                
            };
        }
    }
}
