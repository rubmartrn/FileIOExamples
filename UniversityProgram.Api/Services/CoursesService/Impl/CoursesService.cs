using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Exceptions.HttpException;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.CourseModels.AddModels;
using UniversityProgram.Api.Models.CourseModels.UpdateModels;
using UniversityProgram.Api.Models.CourseModels.ViewModels;
using UniversityProgram.Api.Services.CoursesService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.CoursesService.Impl
{
    public class CoursesService : ICoursesService
    {
        private readonly StudentDbContext _dbContext;

        public CoursesService(StudentDbContext studentDbContext)
        {
            _dbContext = studentDbContext;
        }

        public async Task<IEnumerable<CourseModel>> GetAllAsync(CancellationToken token)
        {
            var courses = await _dbContext.Courses.ToListAsync(token);
            return courses.Select(e => e.Map()!);
        }

        public async Task AddAsync(CourseAddModel model, IValidator<CourseAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            var course = model.Map();
            await _dbContext.Courses.AddAsync(course, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<CourseModel> GetByIdAsync(int id, CancellationToken token)
        {
            var course = await _dbContext.Courses
                .Include(e => e.CourseStudents)
                .FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(course);
            return course.Map()!;
        }

        public async Task<CourseWithStudentsModel> GetWithStudentsAsync(int id, CancellationToken token)
        {
            var course = await _dbContext.Courses
                .Include(e => e.CourseStudents)
                .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(e => e.Id == id, token);

            ObjectValidator.ThrowIfNull(course);

            return course!.MapCourseWithStudentsModel();
        }

        public async Task AddStudentAsync(int id, int studentId, CancellationToken token)
        {
            var course = await _dbContext.Courses.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(course);

            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var courseStudent = new CourseStudent
            {
                Course = course!,
                Student = student!,
            };

            course!.CourseStudents.Add(courseStudent);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var course = await _dbContext.Courses.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(course);

            _dbContext.Courses.Remove(course!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(int id, CourseUpdateModel model, CancellationToken token)
        {
            var course = await _dbContext.Courses.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(course);

            course!.Name = model.Name ?? course.Name;
            course.Fee = model.Fee;

            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
