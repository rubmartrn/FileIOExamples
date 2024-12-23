using System.Text;

namespace Threads;

internal class Program
{
    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        ThreadPool.QueueUserWorkItem(s =>
        {
            Console.WriteLine("Բարև");
        });

        Console.WriteLine("Ավարտ");
    }
}


