﻿using UniversityProgram.Api.Exceptions;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models;
using UniversityProgram.Api.Repositories;

namespace UniversityProgram.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Add(StudentAddModel model, CancellationToken token = default)
        {
            var student = model.Map();

            _uow.StudentRepository.AddStudent(student, token);
            await _uow.Save(token);
        }

        public async Task<IEnumerable<StudentModel>> GetAll(CancellationToken token)
        {
            var students = await _uow.StudentRepository.GetStudents(token);
            return students.Select(e => e.Map());
        }

        public async Task<StudentModel?> GetById(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            return student?.Map();
        }

        public async Task<StudentWithLaptopModel?> GetByIdWithLaptop(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdWithLaptop(id, token);
            return student?.MapToStudentWithLaptop();
        }

        public async Task Update(int id, StudentUpdateModel model, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            if (student == null)
            {
                throw new NotFoundException();
            }
            student.Name = model.Name ?? student.Name;
            student.Email = model.Email is not null ? model.Email : student.Email;
            _uow.StudentRepository.UpdateStudent(student);
            await _uow.Save(token);
        }
    }

    public interface IStudentService
    {
        Task Add(StudentAddModel model, CancellationToken token = default);

        Task<IEnumerable<StudentModel>> GetAll(CancellationToken token);

        Task<StudentModel?> GetById(int id, CancellationToken token);

        Task<StudentWithLaptopModel?> GetByIdWithLaptop(int id, CancellationToken token);
        Task Update(int id, StudentUpdateModel model, CancellationToken token);
    }
}