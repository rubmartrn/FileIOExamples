using UniversityProgram.blazor.Models;

namespace UniversityProgram.blazor.Apis
{
    public interface IStudentApi
    {
        Task<IEnumerable<StudentModel>> GetAll();
    }
}
