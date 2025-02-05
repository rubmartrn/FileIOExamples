using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Exceptions.HttpException;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.StudentModels.AddModels;
using UniversityProgram.Api.Models.StudentModels.UpdateModels;
using UniversityProgram.Api.Models.StudentModels.ViewModels;
using UniversityProgram.Api.Services.CourseBankService.Impl;
using UniversityProgram.Api.Services.StudentsService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.StudentsService.Impl
{
    public class StudentsService : IStudentsService
    {
        private readonly StudentDbContext _dbContext;

        public StudentsService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(StudentAddModel model, IValidator<StudentAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            var student = model.Map();

            await _dbContext.Students.AddAsync(student, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync(CancellationToken token)
        {
            var students = await _dbContext.Students.ToArrayAsync(token);
            return students.Select(e => e.Map());
        }

        public async Task<StudentModel> GetByIdAsync(int id, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(student);
            return student!.Map();
        }

        public async Task<StudentWithLaptopModel> GetByIdWithLaptopAsync(int id, CancellationToken token)
        {
            var student = await _dbContext.Students
           .Include(e => e.Laptop)
           .ThenInclude(e => e!.Cpu)
           .FirstOrDefaultAsync(e => e.Id == id, token);

            ObjectValidator.ThrowIfNull(student);

            return student!.MapToStudentWithLaptop();
        }

        public async Task<StudentWithAddressModel> GetByIdWithAddressAsync(int id, CancellationToken token)
        {
            var student = await _dbContext.Students
                .Include(e => e.Address)
                .FirstOrDefaultAsync(e => e.Id == id, token);

            ObjectValidator.ThrowIfNull(student);
            return student!.MapToStudentWithAddress(); 
        }

        public async Task UpdateAsync(int id, StudentUpdateModel model, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(student);
            student!.Name = model.Name ?? student.Name;
            student!.Email = model.Email is not null ? model.Email : student.Email;
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(student);
            _dbContext.Students.Remove(student!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<StudentWithCourseModel> GetWithCoursesAsync([FromRoute] int id, CancellationToken token)
        {
            var student = await _dbContext.Students
                .Include(e => e.CourseStudents)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id, token);

            ObjectValidator.ThrowIfNull(student);

            return student!.MapStudentWithCourseModel();
        }

        public async Task AddMoneyAsync(int id, decimal money, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == id);
            ObjectValidator.ThrowIfNull(student);
            student!.Money += money;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task PayForCourseAsync([FromRoute] int id, int courseId, CourseBankServiceApi bankApi, CancellationToken token)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(token);
            var student = await _dbContext.Students
              .Include(e => e.CourseStudents)
              .ThenInclude(e => e.Course)
              .FirstOrDefaultAsync(e => e.Id == id, token);

            ObjectValidator.ThrowIfNull(student);

            var courseStudent = student!.CourseStudents.FirstOrDefault(e => e.CourseId == courseId);

            ObjectValidator.ThrowIfNull(courseStudent);

            if (student.Money < courseStudent!.Course.Fee) throw new HttpException(HttpStatusCode.BadRequest, "No Money :("); ;

            try
            {
                student.Money -= courseStudent.Course.Fee;
                courseStudent.Paid = true;
                await _dbContext.SaveChangesAsync(token);
                bankApi.PayCourse(student.Id);
                await transaction.CommitAsync(token);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(token);
                throw new HttpException(HttpStatusCode.NotFound, e.Message);
            }
                
        }

        public async Task AddCourseAsync(int id, int courseId, CancellationToken token)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(student);

            var course = await _dbContext.Courses.FirstOrDefaultAsync(e => e.Id == courseId, token);
            ObjectValidator.ThrowIfNull(course);

            var courseStudent = new CourseStudent()
            {
                Course = course!,
                Student = student!
            };

            student!.CourseStudents.Add(courseStudent);

             await _dbContext.SaveChangesAsync(token);

        }
    }
}
