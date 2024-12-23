using System.Text;

namespace Threads
{
    internal class Program
    {
        private static readonly object lockObject = new object();
        private static readonly object lockObjectForB = new object();

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int a = -1;

            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    lock (lockObject)
                    {
                        Thread.Sleep(500);
                        a++;
                    }
                    Console.WriteLine(a);
                }
            });

            Thread t2 = new Thread(() =>
            {
                while (true)
                {
                    lock (lockObject)
                    {
                        Console.WriteLine(a);
                    }
                }
            });

            int b = 0;

            Thread t3 = new Thread(() =>
            {
                lock (lockObjectForB)
                {
                    b++;
                }
            }
            );

            Thread t4 = new Thread(() =>
            {
                lock (lockObjectForB)
                {
                    Console.WriteLine(b);
                }
            });

            t1.Start();
            t2.Start();
        }
    }
}