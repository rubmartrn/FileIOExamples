using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.UniversityModels.AddModels;
using UniversityProgram.Api.Models.UniversityModels.ViewModels;

namespace UniversityProgram.Api.Map
{
    public static class UniversityMap
    {
        public static UniversityModel Map(this University library)
        {
            return new UniversityModel
            {
                Id = library.Id,
                Name = library.Name,
                Students = library.Students.Select(e => e.Map()).ToList()
            };
        }

        public static University Map(this UniversityAddModel model)
        {
            return new University
            {
                Name = model.Name!,
                Students = model.Students.Select(e => e.Map()).ToList(),
            };
        }
    }
}
