using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course, CancellationToken token = default);
        Task DeleteCourse(Course course, CancellationToken token = default);
        Task<Course?> GetCourseById(int id, CancellationToken token = default);
        Task<IEnumerable<Course>> GetCourses(CancellationToken token = default);
        Task UpdateCourse(Course course, CancellationToken token = default);
    }
}