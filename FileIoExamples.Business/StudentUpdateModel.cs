namespace FileIOExamples.Business
{
    public record StudentUpdateModel
    {
        public string? Address { get; set; }
        public StudentType Type { get; set; }
        public string UniversityName { get; set; } = default!;
    }
}
