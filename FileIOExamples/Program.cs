
IEnumerable<Student> students = new List<Student>()
{
    new Student() {Id = 1, Address = "Yerevan", Name = "Պողոս", UniversityId = 1},
    new Student() {Id = 2, Address = "Yerevan", Name = "Պետրոս", UniversityId = 1},
    new Student() {Id = 3, Address = "Yerevan", Name = "Մարտիրոս", UniversityId = 3},
    new Student() {Id = 4, Address = "Yerevan", Name = "Բարդուղեմիոս", UniversityId = 1}
};

Writer(students);

void Writer(IEnumerable<Student> students)
{
    string folderName = "A";
    string fileName = "data.my";

    string path = Path.Combine(folderName, fileName);
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(folderName);
    }

    if (!File.Exists(path))
    {
        using (var e = File.Create(path))
        {

        }
    }

    using (StreamWriter writer = new StreamWriter(path))
    {
        foreach (var student in students)
        {
            string line = $"{nameof(Student)},{student.Id},{student.Name},{student.Address},{student.UniversityId}";
            writer.WriteLine(line);
        }
    }
}


//void Test(params string[] names)
//{

//}

//Test("Ռուբեն", "Մարտիրոս", "և այլն");


public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public string? Address { get; set; }

    public int UniversityId { get; set; }
}

public class University
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string? City { get; set; }
}
