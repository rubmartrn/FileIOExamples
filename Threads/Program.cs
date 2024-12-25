using System.Text;

namespace Threads;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        await Run();
    }

    static async Task Run()
    {
        Console.WriteLine("Start");
        throw new Exception("սխալ");
    }
}
