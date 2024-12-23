using System.Text;

namespace Threads;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Task.Run(() =>
        {
            Console.Write("Բարև ");

        }).ContinueWith((p) =>
        {
            Console.Write("Ձեզ ");
        }).Wait();

        Task[] tasks = new Task[10];

        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Test(i);
        }

        //Task.WaitAll(tasks);
        Task.WaitAny(tasks);
    }

    static Task Test(int i)
    {
        Console.WriteLine(i);
        return Task.CompletedTask;
    }
}
