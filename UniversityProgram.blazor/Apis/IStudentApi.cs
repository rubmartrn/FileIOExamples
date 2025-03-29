using UniversityProgram.blazor.Models;

namespace UniversityProgram.blazor.Apis
{
    public interface IStudentApi
    {
        Task<IEnumerable<StudentModel>> GetAll();
        Task Delete(int Id);
        Task<StudentModel> GetById(int id);
        Task Update(int id, StudentUpdateModel student);
    }
}
