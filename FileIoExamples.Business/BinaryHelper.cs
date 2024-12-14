using FileIoExamples.Business;

namespace FileIOExamples.Business
{
    public class BinaryHelper
    {
        private readonly IOptionService _optionService;

        public BinaryHelper(IOptionService optionService)
        {
            _optionService = optionService;
        }
        /// <summary>
        /// Երբեք չգրեք չօգտագործվող պարամետրեր!!!
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="student"></param>
        /// <param name="students"></param>
        public void Run(string fileName, string newFileName, Student student, IEnumerable<Student> students)
        {
            string option = _optionService.GetSelectedOption();
            if (option == "1")
            {
                using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    string jsonString = JsonSerializer.Serialize(student);
                    writer.Write(jsonString);
                }
            }
        }
    }
}
