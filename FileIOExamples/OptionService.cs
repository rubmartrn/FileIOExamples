﻿using FileIoExamples.Business;

namespace FileIOExamples
{
    internal class OptionService : IOptionService
    {
        public string GetSelectedOption()
        {
            Console.WriteLine("Ի՞նչ անել");
            return Console.ReadLine();
        }
    }
}
