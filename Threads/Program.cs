namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(1000);
                //Console.Clear();
            }
           
            Thread thread1 = new Thread(CountUp);
            thread1.Start();
            thread1.Join();
            thread1.Name = "Thread1";

            Thread thread3 = new Thread(() => Count(650));
            thread3.Start();

            Thread thread2 = new Thread(CountDown);
            thread2.Start();
            Console.WriteLine("Hello, World!");
        }

        static void Count(int a)
        {
            Console.WriteLine($"thread3: {a}");
        }

        static void CountUp()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(1000);
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
