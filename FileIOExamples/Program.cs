

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var list = new List<int> { 1, 2, 3, 4, 5 };

var m = new List<int>() { 1, 1, 2, 2 };

var s = list.Where(e => e == 2).ToList();

var result = list.First(e => e == 2);
var result1 = list.FirstOrDefault(e => e > 3);

var result2 = list.Single(e => e > 3);
var result3 = list.SingleOrDefault(e => e > 3);

Console.WriteLine();