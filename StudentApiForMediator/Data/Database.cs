namespace StudentApiForMediator.Data
{
    public class Database
    {
        public Database()
        {
            Books = new List<Book>()
            {
                new Book{ Id = 1, Title = "Book 1"},
                new Book{ Id = 2, Title = "Book 2"},
                new Book{ Id = 3, Title = "Book 3"},
            };

            Courses = new List<Course>()
            {
                new Course{ Id = 1, Name = "Course 1"},
                new Course{ Id = 2, Name = "Course 2"},
                new Course{ Id = 3, Name = "Course 3"},
            };
        }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }


    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
