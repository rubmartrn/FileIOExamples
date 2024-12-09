namespace FileIOExamples
{
    public static class Tools
    {
        public static void Write(string json, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(json);
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
