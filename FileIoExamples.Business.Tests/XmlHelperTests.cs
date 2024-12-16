using FileIOExamples.Business;
using Moq;

namespace FileIoExamples.Business.Tests
{
    public class XmlHelperTests
    {
        private Mock<IOptionService> optionServiceMock = new Mock<IOptionService>(MockBehavior.Strict);
        private Mock<ITools> toolsMock = new Mock<ITools>(MockBehavior.Strict);

        private XmlHelper helper => new XmlHelper(optionServiceMock.Object, toolsMock.Object);

        [Fact]
        public void Run_Success()
        {
            //Arrange
            const string fileName = "students.xml";
            const string newFileName = "";
            const string option = "1";
            Student student = new Student()
            {
                Id = 7,
                Name = "Poghos",
                Address = "Yerevan",
                UniversityName = "University"
            };

            IEnumerable<Student> students = new List<Student>();
            optionServiceMock.Setup(e => e.GetSelectedOption()).Returns(option);
            toolsMock.Setup(e => e.Write(It.Is<string>(s => s.Contains("Poghos")), It.IsAny<string>())).Returns(true);

            //Act
            bool result = helper.Run(fileName, newFileName, student, students);

            //Assert
            Assert.True(result);
            optionServiceMock.Verify(e => e.GetSelectedOption(), times: Times.Once);
            toolsMock.Verify(e => e.Write(It.Is<string>(s => s.Contains("Poghos")), fileName), times: Times.Once);
            toolsMock.Verify(e => e.Read(It.IsAny<string>()), times: Times.Never);
        }
    }

    public class XmlHelperTestsIncorrect
    {
        private Mock<XmlHelper> helper = new Mock<XmlHelper>();

        [Fact]
        public void Test()
        {
            //Arrange
            helper.Setup(e => e.Run(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Student>(),
                It.IsAny<IEnumerable<Student>>())).Returns(true);

            //Act
            bool resutl = helper.Object.Run("H", "s", new Student(), new List<Student>());

            //Assert
            Assert.True(resutl);
        }
    }
}
