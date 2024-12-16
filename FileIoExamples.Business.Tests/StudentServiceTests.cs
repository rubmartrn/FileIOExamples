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
    }
}
