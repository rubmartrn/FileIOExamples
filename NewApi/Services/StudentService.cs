using FileIOExamples.Business;
using Microsoft.AspNetCore.Mvc;

namespace NewApi.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
     {
        new Student{
            Id = 1,
            Name = "Petros",
            Address = "Gyumri",
            Type = StudentType.Type1,
            UniversityName = "YSU",
            Date = DateTime.Now
        },
        new Student{
            Id = 2,
            Name = "Poghos",
            Address = "Yerevan",
            Type = StudentType.Type2,
            UniversityName = "YSU",
            Date = DateTime.Now
        },
        new Student{
            Id = 3,
            Name = "Martiros",
            Address = "Ararat",
            Type = StudentType.Type3,
            UniversityName = "YSU",
            Date = DateTime.Now
        }
    };

        public List<Student> GetAll()
        {
            return students;
        }

        public Student? GetById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Update(int id, StudentUpdateModel student)
        {
            var existingStudent = students.FirstOrDefault(x => x.Id == id);

            if (existingStudent != null)
            {
                existingStudent.Address = student.Address;
                existingStudent.Type = student.Type;
                existingStudent.UniversityName = student.UniversityName;
            }
        }

        public void Delete([FromRoute] int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            students.Remove(student);
        }

        public IEnumerable<Student> Filter([FromQuery] string name, [FromQuery] string address)
        {
            return students.Where(e =>
           (!string.IsNullOrEmpty(name) && e.Name.ToLower().Contains(name.ToLower()))
            || (!string.IsNullOrEmpty(address) && e.Address.ToLower().Contains(address.ToLower()))).ToList();
        }
    }
}