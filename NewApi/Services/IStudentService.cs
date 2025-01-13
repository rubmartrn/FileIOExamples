using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;

namespace NewApi.Services
{
    public interface IStudentService
    {
        void Add(Student student);
        void Delete([FromRoute] int id);
        IEnumerable<Student> Filter([FromQuery] string name, [FromQuery] string address);
        List<Student> GetAll();
        Student? GetById(int id);
        void Update(int id, StudentUpdateModel student);
    }
}