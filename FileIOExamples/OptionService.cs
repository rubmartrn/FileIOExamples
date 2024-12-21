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

        public bool VeriifYOption()
        {
            return false;
        }

        public void A()
        {

        }

        public string GetSelectedOption()
        {
            Console.WriteLine("Ի՞նչ անել");
            return Console.ReadLine();
        }
    }
}
