using FileIOExamples.Business;

namespace FileIoExamples.Business
{
    public class StudentService
    {
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 7,
                Name = "Poghos",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now

            },
            new Student()
            {
                Id = 7,
                Name = "Petros",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type3,
                Date = DateTime.Now
            },
            new Student()
            {
                Id = 7,
                Name = "Martiros",
                Address = "Yerevan",
                UniversityName = "University1",
                Type = StudentType.Type2,
                Date = DateTime.Now
            },
            new Student()
            {
                Id = 7,
                Name = "John",
                Address = "Yerevan",
                Type = StudentType.Type1,
                Date = DateTime.Now
            },
        };

        public IEnumerable<Student> GetStudentsByUniversityName(string universityName)
        {
            return students.Where(e => e.UniversityName == universityName);
        }
    }
}
