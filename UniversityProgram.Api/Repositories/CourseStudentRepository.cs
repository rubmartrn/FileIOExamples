using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories;

public class CourseStudentRepository : ICourseStudentRepository
{
    private readonly StudentDbContext _context;

    public CourseStudentRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<CourseStudent?> GetById(int studentId, int courseId, CancellationToken token = default)
    {
        return await _context.CourseStudent
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId, token);
    }

    public void Update(CourseStudent courseStudent, CancellationToken token = default)
    {
        _context.CourseStudent.Update(courseStudent);
    }
}
