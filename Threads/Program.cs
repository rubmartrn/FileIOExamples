using System.Text;
using FileIOExamples.Business;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> students = new List<Student>();

            int a = -1;

            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    students.Add(new Student() { Date = DateTime.Now });
                    Interlocked.Increment(ref a);
                }
            });

            Thread t2 = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (a > -1)
                    {
                        Student s = students[a];
                        Console.WriteLine(s.Date);
                    }
                }
            });
            t1.Start();
            t2.Start();

        }
    }
}
