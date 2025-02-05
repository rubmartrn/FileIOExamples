namespace UniversityProgram.Api.Entities
{
    public class Library
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
