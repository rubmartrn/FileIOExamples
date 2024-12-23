namespace Threads
{
    internal class Example
    {
        public volatile bool isRunning = true;

        public void Run()
        {
            while (isRunning)
            {
                Console.WriteLine("Run");
            }

            Console.WriteLine("Stop");
        }
    }
}