using FluentValidation;
using UniversityProgram.Api.Models.LibraryModels.AddModels;
using UniversityProgram.Api.Models.LibraryModels.ViewModels;
using UniversityProgram.Api.Models.UpdateModels.LibraryModels;

namespace UniversityProgram.Api.Services.LibrariesService.Abstract
{
    public interface ILibraryService
    {
        public Task<IEnumerable<LibraryModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(LibraryAddModel model, IValidator<LibraryAddModel> validator, CancellationToken token);
        public Task<LibraryModel> GetByIdAsync(int id, CancellationToken token);
        public Task AddStudentAsync(int id, int studentId, CancellationToken token);
        public Task RemoveStudentAsync(int id, int studentId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, LibraryUpdateModel model, CancellationToken token);
    }
}
