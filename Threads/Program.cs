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
        await Task.Delay(5000); //Ինտերնետից ինֆո ստանալ
        Console.WriteLine("End");
    }
}
