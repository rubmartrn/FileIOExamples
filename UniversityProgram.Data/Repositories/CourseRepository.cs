using Microsoft.EntityFrameworkCore;
using UniversityProgram.Data.Entities;

namespace UniversityProgram.Data.Repositories
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

        public void AddCourse(Course course, CancellationToken token = default)
        {
            _context.Courses.Add(course);
        }

        public void UpdateCourse(Course course, CancellationToken token = default)
        {
            _context.Courses.Update(course);
        }

        public void DeleteCourse(Course course, CancellationToken token = default)
        {
            _context.Courses.Remove(course);
        }
    }
}