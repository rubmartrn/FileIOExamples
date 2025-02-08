//delegate

//action and func

//events
internal class Program
{
    private static void Main()
    {
        MyEvent += Test;
        MyEvent += Test1;

        MyEvent.Invoke("World");

        MyEvent -= Test;

        MyEvent.Invoke("Barev");
    }

    private static void Test(string s)
    {
        Console.WriteLine("Hello " + s);
    }

    private static void Test1(string m)
    {
        Console.WriteLine("Hi " + m);
    }

    public static event Action<string> MyEvent;
}