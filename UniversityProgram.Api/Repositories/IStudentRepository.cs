using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student, CancellationToken token = default);
        void DeleteStudent(Student student, CancellationToken token = default);
        void UpdateStudent(Student student, CancellationToken token = default);
        Task<Student?> GetStudentById(int id, CancellationToken token = default);

        Task<IEnumerable<Student>> GetStudents(CancellationToken token = default);

        Task<Student?> GetByIdWithLaptop(int id, CancellationToken token = default);

        Task<Student?> GetByIdWithCourse(int id, CancellationToken token = default);
    }
}