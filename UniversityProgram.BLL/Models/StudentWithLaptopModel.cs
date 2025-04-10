﻿namespace UniversityProgram.BLL.Models
{
    public class StudentWithLaptopModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;

        public LaptopWithCpuModel? Laptop { get; set; }
    }
}
