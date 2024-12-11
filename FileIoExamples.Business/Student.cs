using FileIOExamples.Business.Attributes;

namespace FileIOExamples.Business
{
    [NameSwitcher("Name", "Anun")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Address { get; set; }
        public StudentType Type { get; set; }
        public string UniversityName { get; set; } = default!;

        public DateTime? Date { get; set; }
    }
}
