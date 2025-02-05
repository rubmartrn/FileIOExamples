using FluentValidation;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.UpdateModels;
using UniversityProgram.Api.Models.LaptopModels.ViewModels;

namespace UniversityProgram.Api.Services.LaptopsService.Abstract
{
    public interface ILaptopsService
    {
        public Task<IEnumerable<LaptopModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(LaptopAddModel model, IValidator<LaptopAddModel> validator, CancellationToken token);
        public Task<LaptopWithCpuModel> GetCpuAsync(int id, CancellationToken token);
        public Task AddCpuAsync(int id, int cpuId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, LaptopUpdateModel model, CancellationToken token);
    }
}
