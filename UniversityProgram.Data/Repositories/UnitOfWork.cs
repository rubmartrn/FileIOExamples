using UniversityProgram.Data;
using UniversityProgram.Domain.BaseRepositories;

namespace UniversityProgram.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _context;

        public UnitOfWork(StudentDbContext context)
        {
            _context = context;
            CourseStudentRepository = new CourseStudentRepository(_context);
            CourseRepository = new CourseRepository(_context);
            StudentRepository = new StudentRepository(_context);
        }

        public ICourseStudentRepository CourseStudentRepository { get; }

        public ICourseRepository CourseRepository { get; }
        public IStudentRepository StudentRepository { get; }

        public async Task Save(CancellationToken token = default)
        {
            await _context.SaveChangesAsync(token);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}