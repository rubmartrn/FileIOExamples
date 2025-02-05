using FluentValidation;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.CpuModels.UpdateModels;
using UniversityProgram.Api.Models.CpuModels.ViewModels;

namespace UniversityProgram.Api.Services.CpuService.Abstract
{
    public interface ICpuService
    {
        public Task<IEnumerable<CpuModel>> GetAllAsync(CancellationToken token);
        public Task<CpuModel> GetByIdAsync(int id, CancellationToken token);
        public Task AddAsync(CpuAddModel model, IValidator<CpuAddModel> validator, CancellationToken token);
        public Task UpdateAsync(int id, CpuUpdateModel model, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
    }
}
