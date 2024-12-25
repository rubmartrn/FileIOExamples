using System.Text;

namespace Threads;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        await RunSafe();
    }

    static async Task RunUnSafe()
    {
        var unsafeAccount = new BankAccountUnSafe(1000);
        var tasks = new List<Task>();

        for (int i = 0; i < 5; i++)
        {
            tasks.Add(Task.Run(() => unsafeAccount.Send(200)));
        }

        await Task.WhenAll(tasks);
        Console.WriteLine($"Ձեր հաշվին կա {unsafeAccount.GetBalance()}");
    }

    static async Task RunSafe()
    {
        var unsafeAccount = new BankAccountSafe(1000);
        var tasks = new List<Task>();

        for (int i = 0; i < 5; i++)
        {
            tasks.Add(Task.Run(() => unsafeAccount.Send(200)));
        }

        await Task.WhenAll(tasks);
        Console.WriteLine($"Ձեր հաշվին կա {unsafeAccount.GetBalance()}");
    }

}

public class BankAccountSafe
{

    private decimal balance;
    private readonly object lockObject = new object();

    public BankAccountSafe(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Send(decimal amount)
    {
        lock (lockObject)
        {
            if (balance >= amount)
            {
                Thread.Sleep(100);
                balance -= amount;
                Console.WriteLine($"safe sent {amount}, new balance {balance}");
            }
            else
            {
                Console.WriteLine($"Not enough balance {balance}/{amount}");
            }
        }
    }

    public decimal GetBalance()
    {
        lock (lockObject)
        {
            return balance;
        }
    }
}

public class BankAccountUnSafe
{
    private decimal balance;

    public BankAccountUnSafe(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Send(decimal amount)
    {
        if (balance >= amount)
        {
            Thread.Sleep(100);
            balance -= amount;
            Console.WriteLine($"Unsafe sent {amount}, new balance {balance}");
        }
        else
        {
            Console.WriteLine($"Not enough balance {balance}/{amount}");
        }
    }

    public decimal GetBalance()
    {
        return balance;
    }
}