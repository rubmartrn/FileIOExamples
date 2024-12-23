using System.Text;

namespace Threads;

internal class Program
{
    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread t1 = new Thread(Thread1Run);
        Thread t2 = new Thread(Thread2Run);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Ավարտ");
    }

    static void Thread1Run()
    {
        lock (lock1)
        {
            Console.WriteLine("lock 1 from t1");
            Thread.Sleep(1000);
            lock (lock2)
            {
                Console.WriteLine("lock 2 from t1");
            }
        }
    }

    static void Thread2Run()
    {
        lock (lock2)
        {
            Console.WriteLine("lock 2 from t2");
            Thread.Sleep(1000);
            lock (lock1)
            {
                Console.WriteLine("lock 1 from t2");
            }
        }
    }
}


