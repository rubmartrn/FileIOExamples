namespace UniversityProgram.BLL.Models
{
    public class LaptopWithCpuModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public CpuModel? Cpu { get; set; }
    }
}
