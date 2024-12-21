using FileIoExamples.Business;

namespace FileIOExamples
{
    internal class OptionService : IOptionService
    {
        public OptionService()
        {
            
        }

        public bool VeriifYOption()
        {
            return true;
        }

        public string GetSelectedOption()
        {
            Console.WriteLine("Ի՞նչ անել");
            return Console.ReadLine();
        }
    }
}
