using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.CourseModels.AddModels;
using UniversityProgram.Api.Models.CourseModels.ViewModels;
using UniversityProgram.Api.Models.StudentModels.ViewModels;

namespace UniversityProgram.Api.Map
{
    public static class CourseMap
    {
        public static Course Map(this CourseAddModel model)
        {
            return new Course
            {
                Name = model.Name!,
                Fee = model.Fee,
                CourseStudents = model.CourseStudents.ToList(),
            };
        } 
        public static CourseModel? Map(this Course? course)
        {
            return new CourseModel
            {
                Id = course!.Id,
                Name = course.Name,
                Fee = course.Fee,
                Paid = course.Paid ?? "No Information"
            };
        }
        public static CourseWithStudentsModel MapCourseWithStudentsModel(this Course course)
        {
            var models = course.CourseStudents.Select(e => new StudentModel
            {
                Id = e.Student.Id,
                Name = e.Student.Name,
                Email = e.Student.Email,
                Money = e.Student.Money,
            });
            var result = new CourseWithStudentsModel()
            {
                Id = course.Id,
                Name = course.Name,
                Paid = course.Paid,
                Fee = course.Fee
            };
            result.Students.AddRange(models);
            return result;
        }
    }
}
