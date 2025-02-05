using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Exceptions.HttpException;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.LibraryModels.AddModels;
using UniversityProgram.Api.Models.LibraryModels.ViewModels;
using UniversityProgram.Api.Models.UpdateModels.LibraryModels;
using UniversityProgram.Api.Services.LibrariesService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.LibrariesService.Impl
{
    public class LibrariesService : ILibraryService
    {
        private readonly StudentDbContext _dbContext;

        public LibrariesService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LibraryModel>> GetAllAsync(CancellationToken token)
        {
            var Libraries = await _dbContext.Libraries
                .Include(e => e.Students)
                .ToListAsync(token);
            return Libraries.Select(e => e.Map());
        }

        public async Task AddAsync(LibraryAddModel model, IValidator<LibraryAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _dbContext.Libraries.AddAsync(model.Map(), token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<LibraryModel> GetByIdAsync(int id, CancellationToken token)
        {
            var library = await _dbContext.Libraries
                .Include(e => e.Students)
                .FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(library);
            return library!.Map();
        }

        public async Task AddStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var library = await _dbContext.Libraries.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(library);

            library!.Students.Add(student!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task RemoveStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var library = await _dbContext.Libraries.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(library);

            library!.Students.Remove(student!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var library = await _dbContext.Libraries.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(library);

            _dbContext.Libraries.Remove(library!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(int id, LibraryUpdateModel model,  CancellationToken token)
        {
            var library = await _dbContext.Libraries.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(library);

            library!.Name = model.Name ?? library.Name;

            await _dbContext.SaveChangesAsync(token);
        }
    }
}
