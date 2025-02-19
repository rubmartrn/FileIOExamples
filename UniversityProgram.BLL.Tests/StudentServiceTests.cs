using Moq;
using UniversityProgram.BLL.Models;
using UniversityProgram.BLL.Services;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories;

namespace UniversityProgram.BLL.Tests
{
    public class StudentServiceTests
    {
        private IStudentService _studentService;

        private Mock<IStudentRepository> _studentRepositoryMock = new Mock<IStudentRepository>(MockBehavior.Strict);
        private Mock<ICourseStudentRepository> _courseStudentRepositoryMock = new Mock<ICourseStudentRepository>(MockBehavior.Strict);
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);


        public StudentServiceTests()
        {
            _studentService = new StudentService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Payment_Success()
        {
            //Arrange
            const int studentId = 1;
            const int courseId = 12;
            const decimal studentMoney = 500;
            const decimal coursePrice = 100;
            const decimal studentFinalMoney = studentMoney - coursePrice;
            var student = new Data.Entities.Student
            {
                Id = studentId,
                Money = studentMoney
            };
            var courseStudent = new CourseStudent()
            {
                StudentId = studentId,
                CourseId = courseId,
                Course = new Course()
                {
                    Id = courseId,
                    Fee = coursePrice
                },
                Paid = false
            };
            _unitOfWorkMock.Setup(e=>e.StudentRepository).Returns(_studentRepositoryMock.Object);
            _unitOfWorkMock.Setup(e=>e.CourseStudentRepository).Returns(_courseStudentRepositoryMock.Object);

            _studentRepositoryMock.Setup(e => e.GetStudentById(studentId, It.IsAny<CancellationToken>())).ReturnsAsync(student);
            _courseStudentRepositoryMock.Setup(e => e.GetById(studentId, courseId, It.IsAny<CancellationToken>())).ReturnsAsync(courseStudent);
            _studentRepositoryMock.Setup(e => e.UpdateStudent(It.Is<Student>(e=>e.Id == studentId && e.Money == studentFinalMoney), It.IsAny<CancellationToken>()));
            _courseStudentRepositoryMock.Setup(e=>e.Update(It.Is<CourseStudent>(e => e.StudentId == studentId && e.CourseId == courseId && e.Paid == true), It.IsAny<CancellationToken>()));
            _unitOfWorkMock.Setup(e => e.Save(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            //Act
            var result = await _studentService.Pay(studentId, courseId, CancellationToken.None);

            //Assert
            Assert.True(result.Success);
            Assert.Equal("Course paid", result.Message);
        }

        [Fact]
        public async Task Payment_NullStudent_NotFoundResult()
        {
            //Arrange
            const int studentId = 1;
            _unitOfWorkMock.Setup(e => e.StudentRepository).Returns(_studentRepositoryMock.Object);
            _studentRepositoryMock.Setup(e => e.GetStudentById(studentId, It.IsAny<CancellationToken>())).ReturnsAsync((Student)null);

            //Act
            var result = await _studentService.Pay(studentId, 100, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            Assert.Equal(ErrorType.NotFound, result.ErrorType);
        }
    }
}