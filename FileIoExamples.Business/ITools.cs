namespace FileIOExamples.Business
{
    public interface ITools
    {
        string Read(string file);
        void Write(string text, string file);
    }
}