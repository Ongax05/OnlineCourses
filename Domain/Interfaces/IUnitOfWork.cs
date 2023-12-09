using System.Dynamic;

namespace Domain.Interfaces
{
    // Interface for Unit of Work pattern
    public interface IUnitOfWork
    {
        // Property to access the repository for roles
        IRolRepository Roles { get; }

        // Property to access the repository for users
        IUserRepository Users { get; }

        // Property to access the repository for comments
        IComment Comments { get; }

        // Property to access the repository for courses
        ICourse Courses { get; }

        // Property to access the repository for instructors
        IInstructor Instructors { get; }

        // Property to access the repository for qualifications
        IQualification Qualifications { get; }

        // Asynchronous method to save changes to the data base
        Task<int> SaveAsync();
    }
}
