namespace FileIOExamples.Business
{
    public class Tools : ITools
    {
        public void Write(string text, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(text);
            }
        }

        public string Read(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
