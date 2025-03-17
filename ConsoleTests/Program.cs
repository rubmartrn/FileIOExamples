//delegate

//action and func

//events
using ConsoleTests;
using System.Text;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var d = new Downloader();
        d.Downloaded += (s, r) => Console.WriteLine(s);
        d.OnDownladStart += a => Console.WriteLine(a);
        d.OnDownladStart += a =>  SendMail("հաճախորդ@Մեյլ․ռու", a);
        d.Downloaded += (a, r) =>  SendMail("հաճախորդ@Մեյլ․ռու", $"{a}, արդյունքը՝ {r}");

        d.Download();
    }

    static void SendMail(string email, string content)
    {
        Console.WriteLine($"{email} մեյլին ուղարկվել է {content}");
    }
}