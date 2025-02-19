using UniversityProgram.BLL.Exceptions;
using UniversityProgram.BLL.Map;
using UniversityProgram.BLL.Models;
using UniversityProgram.Data.Repositories;

namespace UniversityProgram.BLL.Services
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

        public async Task<Result<StudentWithLaptopModel>> GetByIdWithLaptop(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdWithLaptop(id, token);

            if (student == null)
            {
                return Result<StudentWithLaptopModel>.Error(ErrorType.NotFound);
            }

            if (student.Laptop == null)
            {
                return Result<StudentWithLaptopModel>.Error(ErrorType.LaptopNotFound);
            }

            var data = student.MapToStudentWithLaptop();

            return Result<StudentWithLaptopModel>.Ok(data);
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

        public async Task<Result> Delete(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            if (student == null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            _uow.StudentRepository.DeleteStudent(student, token);
            await _uow.Save(token);
            return Result.Ok("Student deleted");
        }

        public async Task<Result<StudentWithCourseModel>> GetWithCourses(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdWithCourse(id, token);

            if (student == null)
            {
                return Result<StudentWithCourseModel>.Error(ErrorType.NotFound);
            }

            return Result<StudentWithCourseModel>.Ok(student.MapStudentWithCourseModel());
        }

        public async Task<Result> AddMoney(int id, decimal money, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(id, token);
            if (student == null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            student.Money += money;

            _uow.StudentRepository.UpdateStudent(student);
            await _uow.Save(token);

            return Result.Ok("Money added");
        }

        public async Task<Result> Pay(int studentId, int courseId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetStudentById(studentId, token);
            if (student == null)
            {
                return Result.Error(ErrorType.NotFound);
            }

            var courseStudent = await _uow.CourseStudentRepository.GetById(studentId, courseId, token);
            if (courseStudent == null)
            {
                return Result.Error(ErrorType.NotFound);
            }

            if (student.Money <= courseStudent.Course.Fee)
            {
                return Result.Error(ErrorType.CommonError, "ուսանողը բավարար գումար չունի");
            }
            courseStudent.Paid = true;
            _uow.CourseStudentRepository.Update(courseStudent);

            student.Money -= courseStudent.Course.Fee;
            _uow.StudentRepository.UpdateStudent(student);

            await _uow.Save(token);

            return Result.Ok("Course paid");
        }
    }

    public interface IStudentService
    {
        Task Add(StudentAddModel model, CancellationToken token = default);
        Task<Result> AddMoney(int id, decimal money, CancellationToken token);
        Task<Result> Delete(int id, CancellationToken token);

        Task<IEnumerable<StudentModel>> GetAll(CancellationToken token);

        Task<StudentModel?> GetById(int id, CancellationToken token);

        Task<Result<StudentWithLaptopModel>> GetByIdWithLaptop(int id, CancellationToken token);
        Task<Result<StudentWithCourseModel>> GetWithCourses(int id, CancellationToken token);
        Task<Result> Pay(int studentId, int courseId, CancellationToken token);
        Task Update(int id, StudentUpdateModel model, CancellationToken token);
    }
}