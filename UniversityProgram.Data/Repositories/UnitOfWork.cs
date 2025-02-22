using UniversityProgram.Data;
using UniversityProgram.Domain.BaseRepositories;

namespace UniversityProgram.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StudentDbContext _context;
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction;
        public UnitOfWork(StudentDbContext context)
        {
            _context = context;
            CourseStudentRepository = new CourseStudentRepository(_context);
            CourseRepository = new CourseRepository(_context);
            StudentRepository = new StudentRepository(_context);
        }

        public async Task BeginTransaction()
        {
            transaction =  await _context.Database.BeginTransactionAsync();
        }

        public async Task RollBack()
        {
            await transaction.RollbackAsync();
        }

        public async Task Commit()
        {
            await transaction.CommitAsync();
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
            transaction.Dispose();
            _context.Dispose();
        }
    }
}