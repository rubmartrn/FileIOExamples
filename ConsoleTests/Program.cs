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

int Test3(string n)
{
    int a = int.Parse(n);
    return a * 2;
}


Action<string> t;
Action t1;
Func<int> t2;
Func<string, int> t3;

void Test1()
{
    
    t3 = Test3;

    int result = t3(Console.ReadLine());
    Console.WriteLine(result);
}