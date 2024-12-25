using System.Text;

namespace Threads;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        await WriteAsync("a.txt", "Բարև Ձեզ");

        string text = await ReadAsync("a.txt");
        Console.WriteLine(text);
    }

    static async Task WriteAsync(string filePath, string text)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);

        await using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, useAsync: true);
        await stream.WriteAsync(textBytes);
    }

    static async Task<string> ReadAsync(string filePath)
    {

        await using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, useAsync: true);
        byte[] textBytes = new byte[stream.Length];

        await stream.ReadAsync(textBytes, 0, (int)stream.Length);
        string result = Encoding.UTF8.GetString(textBytes);
        return result;
    }
}
