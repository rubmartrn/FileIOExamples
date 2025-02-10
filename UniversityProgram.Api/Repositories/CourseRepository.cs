using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDbContext _context;

        public CourseRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCourses(CancellationToken token = default)
        {
            return await _context.Courses.ToListAsync(token);
        }

        public async Task<Course?> GetCourseById(int id, CancellationToken token = default)
        {
            return await _context.Courses.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task AddCourse(Course course, CancellationToken token = default)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateCourse(Course course, CancellationToken token = default)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync(token);
        }

        public async Task DeleteCourse(Course course, CancellationToken token = default)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync(token);
        }
    }
}