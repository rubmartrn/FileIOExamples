using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Exceptions.HttpException;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.CpuModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.AddModels;
using UniversityProgram.Api.Models.LaptopModels.UpdateModels;
using UniversityProgram.Api.Models.LaptopModels.ViewModels;
using UniversityProgram.Api.Services.LaptopsService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.LaptopsService.Impl
{
    public class LaptopsService : ILaptopsService
    {
        private readonly StudentDbContext _dbContext;
       

        public LaptopsService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LaptopModel>> GetAllAsync(CancellationToken token)
        {
            var laptops = await _dbContext.Laptops
                .Include(e => e.Cpu)
                .ToListAsync(token);
            return laptops.Select(e => e.Map());
        }

        public async Task AddAsync(LaptopAddModel model, IValidator<LaptopAddModel> validator, CancellationToken token)
        {

            ObjectValidator.ThrowIfInvalid(await validator.ValidateAsync(model, token));

            var laptop = new Laptop
            {
                Name = model.Name,
                Cpu = model.Cpu!.Map()
            };

            await _dbContext.Laptops.AddAsync(laptop, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<LaptopWithCpuModel> GetCpuAsync([FromRoute] int id, CancellationToken token)
        {
            var laptop = await _dbContext.Laptops
                .FirstOrDefaultAsync(e => e.Id == id, token);

            ObjectValidator.ThrowIfNull(laptop);

            await _dbContext.Entry(laptop!).Reference(e => e.Cpu).LoadAsync(token);

            return laptop!.MapLaptopWithCpuModel()!;
        }

        public async Task AddCpuAsync(int id, int cpuId, CancellationToken token)
        {
            var laptop = await _dbContext.Laptops.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(laptop);

            var cpu = await _dbContext.Cpus.FirstOrDefaultAsync(e => e.Id == cpuId, token);
            ObjectValidator.ThrowIfNull(cpu);

            laptop!.Cpu = cpu;
            _dbContext.Update(laptop);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var laptop = await _dbContext.Laptops.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(laptop);
            _dbContext.Laptops.Remove(laptop!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(int id, LaptopUpdateModel model, CancellationToken token)
        {
            var laptop = await _dbContext.Laptops.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(laptop);

            laptop!.Name = model.Name ?? laptop.Name;
            laptop.Cpu = model.Cpu;

            await _dbContext.SaveChangesAsync(token);
        }
    }
}
