using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var a = new A();
a.AgeInternal = 4;
a.AgeProtectedInternal = 5;

public class A
{
    private int Age;
    protected int AgeProtected;
    internal int AgeInternal;
    public int AgePublic;
    protected internal int AgeProtectedInternal;
    private protected int AgePrivateProtected;
}

public class B : A
{

    private void Test()
    {
        AgeProtected = 4;
        AgeProtectedInternal = 5;
        AgePrivateProtected = 6;
    }
}