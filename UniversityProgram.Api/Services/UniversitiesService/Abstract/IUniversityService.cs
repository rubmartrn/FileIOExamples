using FluentValidation;
using UniversityProgram.Api.Models.UniversityModels.AddModels;
using UniversityProgram.Api.Models.UniversityModels.UpdateModels;
using UniversityProgram.Api.Models.UniversityModels.ViewModels;

namespace UniversityProgram.Api.Services.UniversitiesService.Abstract
{
    public interface IUniversityService
    {
        public Task<IEnumerable<UniversityModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(UniversityAddModel model, IValidator<UniversityAddModel> validator, CancellationToken token);
        public Task<UniversityModel> GetByIdAsync(int id, CancellationToken token);
        public Task AddStudentAsync(int id, int studentId, CancellationToken token);
        public Task RemoveStudentAsync(int id, int studentId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, UniversityUpdateModel model, CancellationToken token);
    }
}
