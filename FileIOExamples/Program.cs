using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var a = new A()
{
    Name = "Poghos"
};

var aa = new A()
{
    Name = "Poghos"
};

bool result = a == aa;


var t = new T()
{
    Name = "Poghos"
};

var tt = new T()
{
    Name = "Poghos"
};

bool result1 = t == tt;

class A
{
    private int a;
    public string Name { get; set; }
}

//memory<= 16byte
struct MyStruct
{
    
}

record T
{
    public string Name { get; set; }
}