using System.Text;

namespace Threads;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Task.Run(() => Console.WriteLine("Task.Run"));

        Task t = new Task(() =>
        {
            Console.WriteLine("New Task");
        });

        t.Start();

        Task.Factory.StartNew(() =>
        {
            Console.WriteLine("StartNew");
        },
            CancellationToken.None);
    }
}
