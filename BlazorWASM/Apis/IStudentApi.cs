using BlazorWASM.Models;
using Microsoft.AspNetCore.Components;
using Refit;

namespace BlazorWASM.Apis
{
    public interface IStudentApi
    {
        [Get("/student/open")]
        Task<StudentModel> GetOpenModel();

        [Get("/student/private")]

        Task<StudentModel> GetPrivateStudentModel();

        [Get("/student")]
        Task<StudentModel> GetStudentById([Query] int id);

        [Post("/student")]
        Task<StudentModel> Add([Body] StudentModel model, CancellationToken token = default);

        [Delete("/student")]
        Task<StudentModel> Delete(int id);
    }
}
