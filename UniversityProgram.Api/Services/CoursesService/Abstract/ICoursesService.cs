using FluentValidation;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.CourseModels.AddModels;
using UniversityProgram.Api.Models.CourseModels.UpdateModels;
using UniversityProgram.Api.Models.CourseModels.ViewModels;

namespace UniversityProgram.Api.Services.CoursesService.Abstract
{
    public interface ICoursesService
    {
        public Task<IEnumerable<CourseModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(CourseAddModel model, IValidator<CourseAddModel> validator, CancellationToken token);
        public Task<CourseModel> GetByIdAsync(int id, CancellationToken token);
        public Task<CourseWithStudentsModel> GetWithStudentsAsync(int id ,CancellationToken token);
        public Task AddStudentAsync(int id, int studentId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, CourseUpdateModel model, CancellationToken token);
    }
}
