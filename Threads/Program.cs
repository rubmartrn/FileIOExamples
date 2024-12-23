using System.Text;

namespace Threads;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Սկիզբ");
        Test().Wait();

        Console.WriteLine("Ավարտ");
    }

    static Task Test()
    {
        Console.WriteLine("A");
        Task.Delay(20000).Wait();
        Console.WriteLine("B");
        return Task.CompletedTask;
    }
}
