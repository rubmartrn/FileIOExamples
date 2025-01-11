namespace NewApi.Services
{
    public class TestServiceScoped : ITestServiceScoped
    {
        private static int _number = 0;

        public TestServiceScoped()
        {
            _number++;
        }

        public int Test()
        {
            return _number;
        }
    }
}
