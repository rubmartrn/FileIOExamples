namespace NewApi.Services
{
    public class TestServiceTransient : ITestServiceTransient
    {
        private static int _number = 0;

        public TestServiceTransient()
        {
            _number++;
        }

        public int Test()
        {
            return _number;
        }
    }
}
