using UniversityProgram.Data.Entities;

namespace UniversityProgram.Data.Repositories
{
    public interface ICourseRepository
    {
        void AddCourse(Course course, CancellationToken token = default);

        void UpdateCourse(Course course, CancellationToken token = default);

        void DeleteCourse(Course course, CancellationToken token = default);

        Task<Course?> GetCourseById(int id, CancellationToken token = default);

        Task<IEnumerable<Course>> GetCourses(CancellationToken token = default);
    }
}