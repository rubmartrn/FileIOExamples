namespace Threads;

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
                balance = -amount;
                Console.WriteLine($"Unsafe sent {amount}, new balance {balance}");
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
