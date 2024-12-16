namespace FileIoExamples.Business
{
    public class Calc
    {
        public int Add(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }

            if (b < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            if (a == 0 || b == 0)
            {
                return 0;
            }

            int result = a + b;
            return result;
        }
    }
}
