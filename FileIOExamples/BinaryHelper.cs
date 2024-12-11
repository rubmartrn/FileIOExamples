using System.Text.Json;

namespace FileIOExamples
{
    internal class BinaryHelper
    {
        /// <summary>
        /// Երբեք չգրեք չօգտագործվող պարամետրեր!!!
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="student"></param>
        /// <param name="students"></param>
        public static void Run(string fileName, string newFileName, Student student, IEnumerable<Student> students)
        {
            Console.WriteLine("Ի՞նչ անել");
            string option = Console.ReadLine();
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
