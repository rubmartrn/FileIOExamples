namespace FileIOExamples.Business
{
    public interface ITools
    {
        string Read(string file);
        bool Write(string text, string file);
    }
}