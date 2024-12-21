namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(CountUp);
            thread1.Start();
            thread1.Join();
            Thread thread2 = new Thread(CountDown);
            thread2.Start();
            Console.WriteLine("Hello, World!");
        }

        static void CountUp()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"Thread1: {i}");
            }
        }

        static void CountDown()
        {
            for (int i = 100; i >= 0; i--)
            {
                Console.WriteLine($"Thread2: {i}");
            }
        }
    }
}
