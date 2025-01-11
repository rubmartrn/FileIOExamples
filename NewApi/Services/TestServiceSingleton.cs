namespace NewApi.Services
{
    public class TestServiceSingleton : ITestServiceSingleton
    {
        private static int _number = 0;
        public TestServiceSingleton()
        {
            _number++;
        }

        public int Test()
        {
            return _number;
        }
    }
}
