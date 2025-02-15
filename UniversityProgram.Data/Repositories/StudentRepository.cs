using Microsoft.EntityFrameworkCore;
using UniversityProgram.Data;
using UniversityProgram.Data.Entities;

namespace UniversityProgram.Data.Repositories
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

        public void AddStudent(Student student, CancellationToken token = default)
        {
            _context.Students.Add(student);
        }

        public void UpdateStudent(Student student, CancellationToken token = default)
        {
            _context.Students.Update(student);
        }

        public void DeleteStudent(Student student, CancellationToken token = default)
        {
            _context.Students.Remove(student);
        }

        public async Task<Student?> GetByIdWithLaptop(int id, CancellationToken token = default)
        {
            return await _context.Students
                .Include(e => e.Laptop)
                .ThenInclude(e => e.Cpu)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task<Student?> GetByIdWithCourse(int id, CancellationToken token = default)
        {
            return await _context.Students
                .Include(e => e.CourseStudents)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }
    }
}