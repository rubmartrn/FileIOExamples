namespace UniversityProgram.Domain.BaseRepositories
{

    public interface IUnitOfWork
    {
        ICourseStudentRepository CourseStudentRepository { get; }

        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }

        Task Save(CancellationToken token = default);
    }
}
