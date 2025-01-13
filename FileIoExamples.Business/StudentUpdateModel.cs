namespace FileIOExamples.Business
{
    public class StudentUpdateModel
    {
        public string? Address { get; set; }
        public StudentType Type { get; set; }
        public string UniversityName { get; set; } = default!;
    }
}
