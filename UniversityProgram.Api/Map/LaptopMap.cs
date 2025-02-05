using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.CpuModels.ViewModels;
using UniversityProgram.Api.Models.LaptopModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.ViewModels;

namespace UniversityProgram.Api.Map
{
    public static class LaptopMap
    {
        public static LaptopModel Map(this Laptop model)
        {
            return new LaptopModel
            {
                Name = model.Name,
                Id = model.Id,
                Cpu = model.Cpu!.Map()
            };
        }

        public static Laptop Map(this LaptopAddModel model)
        {
            return new Laptop
            {
                Name = model.Name,
                Cpu = model.Cpu!.Map()
            };
        }

        public static LaptopWithCpuModel MapLaptopWithCpuModel(this Laptop laptop)
        {
            return new LaptopWithCpuModel()
            {
                Id = laptop.Id,
                Name = laptop.Name,
                Cpu = laptop.Cpu is null
                 ? null
                 : new CpuModel()
                 {
                     Id = laptop.Cpu.Id,
                     Name = laptop.Cpu.Name
                 }
            };
        }

    }
}
