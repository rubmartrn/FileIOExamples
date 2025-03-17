using UniversityProgram.Domain.BaseRepositories;

namespace UniversityProgram.LocalData.Repositories
{
    public class UnitOfWorkJson : IUnitOfWork
    {
        private readonly IJsonDataService _service;

        public UnitOfWorkJson(IJsonDataService service)
        {
            this._service = service;
        }

        public ICourseStudentRepository CourseStudentRepository => throw new NotImplementedException();

        public ICourseRepository CourseRepository => throw new NotImplementedException();

        public IStudentRepository StudentRepository => new StudentRepositoryJson(_service);

        public void Test()
        {
            throw new NotImplementedException();
        }

        public async Task Save(CancellationToken token = default)
        {
           await  _service.SaveChangesAsync();
        }
    }
}
