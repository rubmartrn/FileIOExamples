namespace FileIoExamples.Business.Tests
{
    public class CalcTests
    {
        private Calc _calc;

        [Fact]
        public void Add_Success()
        {
            //Arrange
            _calc = new Calc();
            const int a = 5;
            const int b = 7;
            const int expectedResult = 12;

            //Act
            int result = _calc.Add(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_0value_Success()
        {
            //Arrange
            _calc = new Calc();
            const int a = 0;
            const int b = 7;
            const int expectedResult = 0;

            //Act
            int result = _calc.Add(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(0, 3, 0)]
        [InlineData(1, 0, 0)]
        public void Add_AllCases_Success(int a, int b, int expectedResult)
        {
            //Arrange
            _calc = new Calc();

            //Act
            int result = _calc.Add(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void Add_NegativeA_ThrowsException()
        {
            //Arrange
            _calc = new Calc();
            const int a = -5;
            const int b = 7;

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _calc.Add(a, b));
        }

        [Fact]
        public void Add_NegativeB_ThrowsException()
        {
            //Arrange
            _calc = new Calc();
            const int a = 5;
            const int b = -7;

            //Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => _calc.Add(a, b));

            //Assert
            Assert.Null(ex.InnerException);
            Assert.Equal("b", ex.ParamName);
        }
    }
}
