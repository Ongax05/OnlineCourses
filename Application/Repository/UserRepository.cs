using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;
namespace Application.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly CoursesDbContext _context;

    public UserRepository(CoursesDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public override async Task<User> GetByIdAsync(int Id)
    {
        return await _context.Users
            .Where(u=>u.Id == Id)
            .Include(u => u.Instructor)
            .FirstOrDefaultAsync();
            
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }
}
