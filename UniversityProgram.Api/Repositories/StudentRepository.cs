using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents(CancellationToken token = default)
        {
            return await _context.Students.ToListAsync(token);
        }

        public async Task<Student?> GetStudentById(int id, CancellationToken token = default)
        {
            return await _context.Students.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task AddStudent(Student student, CancellationToken token = default)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateStudent(Student student, CancellationToken token = default)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync(token);
        }

        public async Task DeleteStudent(Student student, CancellationToken token = default)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync(token);
        }
    }
}
