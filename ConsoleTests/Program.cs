//delegate

//action and func

//events
using System.Text;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Action a = () => Console.WriteLine("Բարև");

        Action<string> b = s =>
        { 
            Console.WriteLine(s);
            Console.WriteLine(s);
            Console.WriteLine(s);
            Console.WriteLine(s);
            if (s == "Հաջող")
            {
                Console.WriteLine("Հաջող");
            }
        };

        a.Invoke();
        b.Invoke("Հաջող");
    }
}