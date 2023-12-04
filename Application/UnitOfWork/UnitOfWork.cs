using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Percistency.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CoursesDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    public UnitOfWork(CoursesDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    private IComment _Comments;
    public IComment Comments
    {
        get
        {
            _Comments ??= new CommentRepository(_context);
            return _Comments;
        }
    }
    private ICourse _Courses;
    public ICourse Courses
    {
        get
        {
            _Courses ??= new CourseRepository(_context);
            return _Courses;
        }
    }
    private IInstructor _Instructors;
    public IInstructor Instructors
    {
        get
        {
            _Instructors ??= new InstructorRepository(_context);
            return _Instructors;
        }
    }
    private IQualification _Qualifications;
    public IQualification Qualifications
    {
        get
        {
            _Qualifications ??= new QualificationRepository(_context);
            return _Qualifications;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
