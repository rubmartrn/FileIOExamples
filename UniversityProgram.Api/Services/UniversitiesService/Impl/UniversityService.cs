using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Exceptions.HttpException;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.UniversityModels.AddModels;
using UniversityProgram.Api.Models.UniversityModels.UpdateModels;
using UniversityProgram.Api.Models.UniversityModels.ViewModels;
using UniversityProgram.Api.Services.UniversitiesService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.UniversitiesService.Impl
{
    public class UniversityService : IUniversityService
    {
        private readonly StudentDbContext _dbContext;

        public UniversityService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync(CancellationToken token)
        {
            var universities = await _dbContext.Universities
                .Include(e => e.Students)
                .ToListAsync(token);
            return universities.Select(e => e.Map());
        }

        public async Task AddAsync(UniversityAddModel model, IValidator<UniversityAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _dbContext.Universities.AddAsync(model.Map(), token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<UniversityModel> GetByIdAsync(int id, CancellationToken token)
        {
            var university = await _dbContext.Universities
                .Include(e => e.Students)
                .FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(university);
            return university!.Map();
        }

        public async Task AddStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var university = await _dbContext.Universities.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(university);

            university!.Students.Add(student!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task RemoveStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var university = await _dbContext.Universities.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(university);

            university!.Students.ToList().Remove(student!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var university = await _dbContext.Universities.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(university);

            _dbContext.Universities.Remove(university!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(int id, UniversityUpdateModel model, CancellationToken token)
        {
            var university = await _dbContext.Universities.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(university);

            university!.Name = model.Name ?? university.Name;

            await _dbContext.SaveChangesAsync(token);
        }
    }
}
