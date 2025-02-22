
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Domain.BaseRepositories;

public interface ICourseStudentRepository
{
    Task<CourseStudent?> GetById(int studentId, int courseId, CancellationToken token = default);
    void Update(CourseStudent courseStudent, CancellationToken token = default);
}