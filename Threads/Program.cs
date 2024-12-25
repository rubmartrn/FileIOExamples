using System.Text;

namespace Threads;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        CancellationTokenSource src = new CancellationTokenSource();
        src.CancelAfter(5000);
        try
        {
            int a = Run(src.Token).Result;
            Console.WriteLine(a);
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

    static Task<int> Run(CancellationToken token)
    {
        for (int i = 0; i < 10000; i++)
        {
            token.ThrowIfCancellationRequested();
            //if (token.IsCancellationRequested)
            //{
            //    return Task.FromCanceled(token);
            //}
            Task.Delay(1000, token).Wait(token);
            Console.WriteLine(i);
        }
        return Task.FromResult(4);
    }
}
