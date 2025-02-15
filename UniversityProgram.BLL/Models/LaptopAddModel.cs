namespace UniversityProgram.BLL.Models
{
    public class LaptopAddModel
    {
        public string Name { get; set; } = default!;
        public int? StudentId { get; set; }

        public CpuAddModel? Cpu { get; set; }
    }
}
