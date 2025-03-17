namespace ConsoleTests
{
    internal class Downloader
    {

        public event Action<string> OnDownladStart;

        public event Action<string, string> Downloaded;

        private string Result { get; set; }
        public void Download()
        {
            OnDownladStart?.Invoke("սկսվել է");

            Result = "Ինչ որ արդյունք";

            Downloaded?.Invoke("պատրաստ է", Result);
        }
    }
}