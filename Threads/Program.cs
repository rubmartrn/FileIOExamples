using System.Text;

namespace Threads;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        CancellationTokenSource src = new CancellationTokenSource();
        try
        {
            Cancel(src);
            Run(src.Token);
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine("Գործողությունը չեղարկվել է");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    static Task Cancel(CancellationTokenSource src)
    {
        Task.Delay(5000).Wait();
        src.Cancel();
        return Task.CompletedTask;
    }

    static Task Run(CancellationToken token)
    {
        for (int i = 0; i < 10000; i++)
        {
            if (token.IsCancellationRequested)
            {
                return Task.FromCanceled(token);
            }
            Task.Delay(1000, token).Wait(token);
            Console.WriteLine(i);
        }
        return Task.CompletedTask;
    }
}
