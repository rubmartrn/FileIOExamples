using AutoMapper;
using UniversityProgram.Data.Entities;
using UniversityProgram.BLL.Models;

namespace UniversityProgram.Api.Map;

public class LaptopProfile : Profile
{
    public LaptopProfile()
    {
        CreateMap<LaptopAddModel, Laptop>();
        CreateMap<Laptop, LaptopModel>()
            .ForMember(e => e.Id, o => o.Ignore())
            .ReverseMap();

        CreateMap<Laptop, LaptopWithCpuName>()
            .ForMember(e=>e.LaptopName, o=>o.MapFrom(l=>l.Name))
            .ForMember(e=>e.Name, o=>o.MapFrom(l=>l.Cpu.Name));
    }
}