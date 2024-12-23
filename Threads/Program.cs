using System.Text;

namespace Threads;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Task<int> t = Task.Run(() =>
        {
            Task.Delay(10000).Wait();
            return 42;
        });

        int a = t.Result;
        Console.WriteLine(a);

        int b = Test().Result;
        Console.WriteLine(b);
    }

    static Task<int> Test()
    {
        Console.WriteLine("A");
        Console.WriteLine("B");
        return Task.FromResult(43);
    }
}
