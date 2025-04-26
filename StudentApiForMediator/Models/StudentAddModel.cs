namespace StudentApiForMediator.Models
{
    public record StudentAddModel(int Id, string? Name, string? Email, int BookId, int CourseId);
}
