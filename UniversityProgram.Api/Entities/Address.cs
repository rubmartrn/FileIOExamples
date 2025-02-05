namespace UniversityProgram.Api.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; } = default!;

        public string City { get; set; } = default!;

        public string Street { get; set; } = default!;

        public int? StudentId { get; set; }

        public Student? Student { get; set; }

    }
}
