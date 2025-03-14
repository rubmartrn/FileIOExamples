﻿namespace UniversityProgram.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string Address { get; set; } = default!;
        public string? Address2 { get; set; }
        public Laptop? Laptop { get; set; } = default!;

        public int? LibraryId { get; set; }
        public Library? Library { get; set; }

        public decimal Money { get; set; }

        public IEnumerable<University> Universities { get; set; } = new List<University>();
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
