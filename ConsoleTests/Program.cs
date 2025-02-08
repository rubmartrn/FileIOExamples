//delegate

//action and func

//events
using System.Text;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Func<string, int> f = s =>
        {
            int u = int.Parse(s);
            int r = u * 2;
            return r;
        };

        var result = f.Invoke("123");
        Console.WriteLine(result);
    }
}