using System.Reflection;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

const string folderName = "A";
const string fileName = "data.my";
string path = Path.Combine(folderName, fileName);

IEnumerable<Student> students = new List<Student>()
{
    new Student() {Id = 1, Address = "Yerevan", Name = "Պողոս", UniversityId = 1},
    new Student() {Id = 2, Address = "Yerevan", Name = "Պետրոս", UniversityId = 1},
    new Student() {Id = 3, Address = "Yerevan", Name = "Մարտիրոս", UniversityId = 3},
    new Student() {Id = 4, Address = "Yerevan", Name = "Բարդուղեմիոս", UniversityId = 1}
};

IEnumerable<University> universities = new List<University>()
{
    new University()
    {
        Id = 1, City = "Yerevan", Name = "Առաջին",
    },
    new University()
    {
        Id = 3, City = "Yerevan", Name = "Երրորդ",
    }
};

List<object> allData = new List<object>();
allData.AddRange(students);
allData.AddRange(universities);

//Write(allData);
List<object> data = Read().ToList();
List<Student> readStudents = data.Where(e => e.GetType().Name == nameof(Student)).Cast<Student>().ToList();
List<University> readUniversities = data.Where(e => e.GetType().Name == "University")
                                                .Select(
                                                    e => (e as University)!
                                                ).ToList();

foreach (var student in readStudents)
{
    Console.WriteLine($"id:  {student.Id}, Name: {student.Name}");
}

while (true)
{
    Console.WriteLine("Ո՞ր ուսանողին եք ուզում ստուգել");
    int id = int.Parse(Console.ReadLine());
    Student current = readStudents.First(e => e.Id == id);
    University university = readUniversities.First(e => e.Id == current.UniversityId);

    Console.WriteLine($"{current.Name} ուսանողը սովորում է {university.Name} համասլարանում");

}

void Write<T>(IEnumerable<T> items)
{
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
        foreach (var item in items)
        {
            Type t = item.GetType();
            string line = $"{t.FullName}";
            foreach (var prop in t.GetProperties())
            {
                line += $",{prop.GetValue(item)}";
            }
            writer.WriteLine(line);
        }
    }
}

IEnumerable<object> Read()
{
    using (StreamReader reader = new StreamReader(path))
    {
        while (true)
        {
            string? l = reader.ReadLine();
            if (l is null)
            {
                break;
            }
            string[] @params = l!.Split(",");
            string typeName = @params[0];
            object newType = Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, typeName).Unwrap();
            PropertyInfo[] props = newType.GetType().GetProperties();

            int n = 1;
            foreach (var prop in props)
            {
                string propertyType = prop.PropertyType.Name;
                if (propertyType == "Int32")
                {
                    prop.SetValue(newType, int.Parse(@params[n]));
                }
                else
                {
                    prop.SetValue(newType, @params[n]);
                }
                n++;
            }

            yield return newType;
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
