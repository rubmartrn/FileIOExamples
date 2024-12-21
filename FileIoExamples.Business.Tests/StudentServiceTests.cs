namespace FileIoExamples.Business.Tests
{
    public class StudentServiceTests
    {
        private StudentService _service;

        [Fact]
        public void GetStudentsByUniversityName_Success()
        {
            //Arrange 
            _service = new StudentService();
            const string universityName = "University";
            const string expectedStudentName = "Poghos";
            const int NormalName = 7;

            //Act
            var result = _service.GetStudentsByUniversityName(universityName);

            //Arrange
            var students = result.ToList();
            Assert.NotEmpty(students);
            Assert.Contains(expectedStudentName, students.Select(e => e.Name));
        }

        [Fact]
        public void GetStudentsByUniversityName_MissingUniverityName_Success()
        {
            //Arrange 
            _service = new StudentService();
            const string missingUniversityName = "University1234";

            //Act
            var result = _service.GetStudentsByUniversityName(missingUniversityName);

            //Arrange
            Assert.Empty(result);
        }

        [Fact]
        public void GetById_Success()
        {
            //Arrange
            _service = new StudentService();
            const int id = 1;
            string name = "Poghos";

            //Act
            var result = _service.GetById(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
        }


        [Fact]
        public void GetById_NotExist_ReturnsNull()
        {
            //Arrange
            _service = new StudentService();

            const int id = 100;

            //Act
            var result = _service.GetById(id);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public void GetById_MultipleStudents_ThrowsException()
        {
            //Arrange
            _service = new StudentService();

            const int id = 7;

            //Act
            //Assert
            Assert.Throws<Exception>(() => _service.GetById(id));
        }
    }
}
