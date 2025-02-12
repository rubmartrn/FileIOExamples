using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student, CancellationToken token = default);
        Task DeleteStudent(Student student, CancellationToken token = default);
        Task<Student?> GetStudentById(int id, CancellationToken token = default);
        Task<IEnumerable<Student>> GetStudents(CancellationToken token = default);
        Task UpdateStudent(Student student, CancellationToken token = default);
        Task<Student?> GetByIdWithLaptop(int id, CancellationToken token = default);
    }
}