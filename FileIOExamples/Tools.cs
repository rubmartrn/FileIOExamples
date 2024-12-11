namespace FileIOExamples
{
    public static class Tools
    {
        public static void Write(string text, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(text);
            }
        }

        public static string Read(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
