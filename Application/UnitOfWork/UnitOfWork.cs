using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Percistency.Data;

namespace Application.UnitOfWork
{
    // Unit of Work class for managing repositories and database interactions
    public class UnitOfWork : IUnitOfWork
    {
        // Private field to store the instance of CoursesDbContext
        private readonly CoursesDbContext _context;

        // Repositories
        private IRolRepository _roles;
        private IUserRepository _users;
        private IComment _comments;
        private ICourse _courses;
        private IInstructor _instructors;
        private IQualification _qualifications;

        // Constructor to initialize the UnitOfWork with a CoursesDbContext
        public UnitOfWork(CoursesDbContext context)
        {
            _context = context;
        }

        // Property to access the repository for roles
        public IRolRepository Roles
        {
            get
            {
                _roles ??= new RolRepository(_context);
                return _roles;
            }
        }

        // Property to access the repository for users
        public IUserRepository Users
        {
            get
            {
                _users ??= new UserRepository(_context);
                return _users;
            }
        }

        // Property to access the repository for comments
        public IComment Comments
        {
            get
            {
                _comments ??= new CommentRepository(_context);
                return _comments;
            }
        }

        // Property to access the repository for courses
        public ICourse Courses
        {
            get
            {
                _courses ??= new CourseRepository(_context);
                return _courses;
            }
        }

        // Property to access the repository for instructors
        public IInstructor Instructors
        {
            get
            {
                _instructors ??= new InstructorRepository(_context);
                return _instructors;
            }
        }

        // Property to access the repository for qualifications
        public IQualification Qualifications
        {
            get
            {
                _qualifications ??= new QualificationRepository(_context);
                return _qualifications;
            }
        }

        // Asynchronous method to save changes to the underlying data store
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
