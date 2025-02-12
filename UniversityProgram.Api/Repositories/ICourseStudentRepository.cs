using UniversityProgram.Api.Entities;

namespace UniversityProgram.Api.Repositories;

public interface ICourseStudentRepository
{
    Task<CourseStudent?> GetById(int studentId, int courseId, CancellationToken token = default);
    void Update(CourseStudent courseStudent, CancellationToken token = default);
}