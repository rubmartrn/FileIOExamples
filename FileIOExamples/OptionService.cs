using FileIoExamples.Business;

namespace FileIOExamples
{
    internal class OptionService : IOptionService
    {
        public OptionService()
        {
            
        }

        public int Urish()
        {
            return 1;
        }

        public string GetSelectedOption()
        {
            Console.WriteLine("Ի՞նչ անել");
            return Console.ReadLine();
        }
    }
}
