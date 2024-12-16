using System.Xml.Serialization;
using FileIoExamples.Business;

namespace FileIOExamples.Business
{
    /// <summary>
    /// Բարև
    /// </summary>
    public class XmlHelper
    {
        private readonly IOptionService _optionService;
        private readonly ITools tools;

        public XmlHelper(IOptionService optionService, ITools tools)
        {
            this._optionService = optionService;
            this.tools = tools;
        }

        /// <summary>
        /// Երբեք չգրեք չօգտագործվող պարամետրեր!!!
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="student"></param>
        /// <param name="students"></param>
        public bool Run(string fileName, string newFileName, Student student, IEnumerable<Student> students)
        {
            string option = _optionService.GetSelectedOption();
            XmlSerializer studentSerializer = new XmlSerializer(typeof(Student));

            if (option == "1")
            {
                string result = string.Empty;// = "";
                using (StringWriter writer = new StringWriter())
                {
                    studentSerializer.Serialize(writer, student);
                    result = writer.ToString();
                }

                return tools.Write(result, fileName);
            }
            else
            {
                string xml = tools.Read(fileName);
                using (StringReader reader = new StringReader(xml))
                {
                    object deserialized = studentSerializer.Deserialize(reader);
                    if (deserialized is Student newStudent)
                    {
                        Console.WriteLine(newStudent.Name);
                    }
                }

                return true;
            }
        }
    }
}
