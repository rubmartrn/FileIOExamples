//delegate

//action and func

//events

Test1();

void Test(string s)
{
    Console.WriteLine("Hello " + s);
}
void Test2(string s)
{
    Console.WriteLine("Hi " + s);
}

void Test1()
{
    MyDelegate del;
    while (true)
    {
        var result = Console.ReadLine();
        if (result == "1")
        {
            del = Test;
        }
        else
        {
            del = Test2;
        }

        del("World");
    }
}

internal delegate void MyDelegate(string s);