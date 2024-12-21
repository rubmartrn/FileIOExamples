using System.Text;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Example example = new Example();
            Thread t = new Thread(example.Run);
            t.Start();
            Console.WriteLine("Սեղմեք ինչ որ բան ստոպի համար");
            Console.ReadKey();
            example.isRunning = false;
            Console.WriteLine(example.isRunning);
            t.Join();
        }
    }
}
