using FileIOExamples.Business;

namespace FileIoExamples.Business
{
    public class StudentService
    {
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Poghos",
                Address = "Yerevan",
                UniversityName = "University",
                Type = StudentType.Type1,
                Date = DateTime.Now

            },
            new Student()
            {
                Id = 2,
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

        //1․ վերադարփնել ուսանողին ըստ այդիի
        // եթե չկա տենց ուսանող, վերադարձնել null
        // եթե կա մեկից ավել ուսանող տվյալ այդիով, exception
        public Student? GetById(int id)
        {
            if (students.Where(e => e.Id == id).Count() > 1)
            {
                throw new Exception();
            }
            return students.FirstOrDefault(e => e.Id == id);
        }
    }
}
