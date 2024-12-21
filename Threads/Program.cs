using System.Text;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int a = 0;

            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Interlocked.Increment(ref a);
                }
            });

            Thread t2 = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(a);
                }
            });
            t1.Start();
            t2.Start();

        }
    }
}
