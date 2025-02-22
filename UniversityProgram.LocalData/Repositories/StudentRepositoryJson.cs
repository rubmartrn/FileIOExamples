using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.LocalData.Repositories
{
    public class StudentRepositoryJson : IStudentRepository
    {
        private readonly IJsonDataService _service;

        public StudentRepositoryJson(IJsonDataService service)
        {
            _service = service;
        }

        public void AddStudent(Student student, CancellationToken token = default)
        {
            _service.WriteData(student);
        }

        public void DeleteStudent(Student student, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetByIdWithCourse(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetByIdWithLaptop(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetStudentById(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudents(CancellationToken token = default)
        {
           var student = _service.ReadData<Student>();
            return Task.FromResult(new List<Student> { student }.AsEnumerable());
        }       

        public void UpdateStudent(Student student, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
