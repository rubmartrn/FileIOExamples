using System.Xml.Serialization;

namespace FileIOExamples
{
    public class XmlHelper
    {
        public static void Run(string fileName, string newFileName, Student student, IEnumerable<Student> students)
        {
            Console.WriteLine("Ի՞նչ անել");
            string option = Console.ReadLine();
            XmlSerializer studentSerializer = new XmlSerializer(typeof(Student));

            if (option == "1")
            {
                string result = string.Empty;// = "";
                using (StringWriter writer = new StringWriter())
                {
                    studentSerializer.Serialize(writer, student);
                    result = writer.ToString();
                }

                Tools.Write(result, fileName);
            }
            else
            {
                string xml = Tools.Read(fileName);
                using (StringReader reader = new StringReader(xml))
                {
                    object deserialized = studentSerializer.Deserialize(reader);
                    if (deserialized is Student newStudent)
                    {
                        Console.WriteLine(newStudent.Name);
                    }
                }
            }
        }
    }
}
