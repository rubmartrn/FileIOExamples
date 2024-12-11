namespace FileIOExamples
{
    internal class OptionService
    {
        internal string GetSelectedOption()
        {
            Console.WriteLine("Ի՞նչ անել");
            return Console.ReadLine();
        }
    }
}
