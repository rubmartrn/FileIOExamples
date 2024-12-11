namespace FileIOExamples.Business.Attributes
{
    internal class NameSwitcherAttribute : Attribute
    {
        public NameSwitcherAttribute(string originalName, string jsonName)
        {
            OriginalName = originalName;
            JsonName = jsonName;
        }

        public string OriginalName { get; set; }
        public string JsonName { get; set; }
    }
}
