using System.Dynamic;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    Task<int> SaveAsync();
    IComment Comments { get; }
    ICourse Courses { get; }
    ICourseImage CourseImages { get; }
    IInstructor Instructors { get; }
    IQualification Qualifications { get; }
}
