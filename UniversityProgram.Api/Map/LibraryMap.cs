using System.Runtime.CompilerServices;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.LibraryModels.AddModels;
using UniversityProgram.Api.Models.LibraryModels.ViewModels;

namespace UniversityProgram.Api.Map
{
    public static class LibraryMap
    {
        public static LibraryModel Map(this Library library)
        {
            return new LibraryModel
            {
                Id = library.Id,
                Name = library.Name,
                Students = library.Students.Select(e => e.Map()).ToList()
            };
        } 

        public static Library Map(this LibraryAddModel model)
        {
            return new Library
            {
                Name = model.Name!,
                Students = model.Students.Select(e => e.Map()).ToList(),
            };
        }
    }
}
