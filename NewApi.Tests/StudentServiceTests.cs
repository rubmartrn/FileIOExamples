using FileIOExamples.Business;
using NewApi.Services;

namespace NewApi.Tests
{
    public class StudentServiceTests
    {
        private StudentService service = new StudentService();

        [Fact]
        public void GetById_Success()
        {
            //Arrange
            service.Add(new Student
            {
                Id = 1,
                Name = "Poghos",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now
            }); 
            service.Add(new Student
            {
                Id = 2,
                Name = "Martiros",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now
            }); 
            service.Add(new Student
            {
                Id = 3,
                Name = "Petros",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now
            });

            //Act
            var student = service.GetById(1);

            //Assert
            Assert.NotNull(student);
            Assert.Equal("Poghos", student.Name);
        }

        [Fact]
        public void Delete_Success()
        { 
            
            //Arrange
            service.Add(new Student
            {
                Id = 1,
                Name = "Poghos",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now
            });
            service.Add(new Student
            {
                Id = 2,
                Name = "Martiros",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now
            });
            service.Add(new Student
            {
                Id = 3,
                Name = "Petros",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now
            });

            //Act
            service.Delete(1);

            //Assert
            var students = service.GetAll();
            Assert.DoesNotContain(students, x => x.Id == 1);
        }
    }
}