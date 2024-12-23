namespace Threads;

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
            balance = -amount;
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
