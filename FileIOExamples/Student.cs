using FileIOExamples.Attributes;

namespace FileIOExamples
{
    [NameSwitcher("Name", "Anun")]
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Address { get; set; }
        public StudentType Type { get; set; }
        public string UniversityName { get; set; } = default!;

        public DateTime? Date { get; set; }
    }
}
