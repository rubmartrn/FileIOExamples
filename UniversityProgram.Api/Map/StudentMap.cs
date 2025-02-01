using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Map
{
    public static class StudentMap
    {
        public static StudentWithLaptopModel MapToStudentWithLaptop(this Student student)
        {
            return new StudentWithLaptopModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Laptop = student.Laptop is not null
                    ? new LaptopWithCpuModel()
                    {
                        Id = student.Laptop.Id,
                        Name = student.Laptop.Name,
                        Cpu = student.Laptop.Cpu is not null ? new CpuModel()
                        {
                            Id = student.Laptop.Cpu.Id,
                            Name = student.Laptop.Cpu.Name
                        } : null
                    }
                    : null
            };
        }

        public static StudentModel Map(this Student student)
        {
            return new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Money = student.Money
            };
        }

        public static Student Map(this StudentAddModel studentModel)
        {
            return new Student
            {
                Name = studentModel.Name,
                Email = studentModel.Email
            };
        }

        public static StudentWithCourseModel MapStudentWithCourseModel(this Student student)
        {
            var models = student.CourseStudents.Select(e => new CourseModel()
            {
                Id = e.Course.Id,
                Name = e.Course.Name,
                Fee = e.Course.Fee,
                Paid = e.Paid ? "Այո" : "Ոչ"
            }).ToList();

            var result = new StudentWithCourseModel()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Money = student.Money
            };

            result.Courses.AddRange(models);

            return result;
        }
    }
}