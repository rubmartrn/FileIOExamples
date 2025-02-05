namespace UniversityProgram.Api.Entities
{
    public class Cpu
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int? LaptopId { get; set; } = default!;

        public Laptop? Laptop { get; set; } = default!;
    }
}
