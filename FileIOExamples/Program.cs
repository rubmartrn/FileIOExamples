using System.Text;

Console.OutputEncoding = Encoding.UTF8;

IEnumerable<int> Test1()
{
    var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    foreach (var number in numbers)
    {
        yield return number;
    }
}

IEnumerable<int> Test2()
{
    var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    for (int i = 0; i < numbers.Count; i++)
    {
        yield return numbers[i];
    }
}

IEnumerable<int> Test3(int a)
{
    yield return 1;
    if (a < 7)
    {
        yield break;
    }

    var t = Console.ReadLine();
    if (t == "H")
    {
        yield return 6;
    }
}

var result1 = Test1().ToList();
var result2 = Test2().ToList();
while (true)
{
    var result3 = Test3(8).ToList();
    Console.WriteLine();
}