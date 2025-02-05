using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.CpuModels.UpdateModels;
using UniversityProgram.Api.Models.CpuModels.ViewModels;
using UniversityProgram.Api.Services.CpuService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.CpuService.Impl
{
    public class CpuService : ICpuService
    {
        private readonly StudentDbContext _dbContext;

        public CpuService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(CpuAddModel model, IValidator<CpuAddModel> validator, CancellationToken token)
        {
           ObjectValidator.ThrowIfInvalid(validator.Validate(model));
           await _dbContext.Cpus.AddAsync(model.Map()!, token);
           await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var cpu = await _dbContext.Cpus.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(cpu);
            _dbContext.Cpus.Remove(cpu!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<CpuModel>> GetAllAsync(CancellationToken token)
        {
            var cpus = await _dbContext.Cpus
                .Include(e => e.Laptop)
                .ToListAsync(token);
            return cpus.Select(cpu => cpu.Map());
        }

        public async Task<CpuModel> GetByIdAsync(int id, CancellationToken token)
        {
            var cpu = await _dbContext.Cpus.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(cpu);
            return cpu!.Map();
        }

        public async Task UpdateAsync(int id, CpuUpdateModel model, CancellationToken token)
        {
            var cpu = await _dbContext.Cpus.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(cpu);
            cpu!.Name = model.Name ?? cpu.Name;

            await _dbContext.SaveChangesAsync(token);
        }
    }
}
