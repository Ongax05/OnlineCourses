using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;

namespace Application.Repository
{
    // Repository class for handling users, inheriting from the GenericRepository<User> class and implementing IUserRepository interface
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        // Private field to store the instance of CoursesDbContext
        private readonly CoursesDbContext _context;

        // Constructor to initialize the repository with a CoursesDbContext
        public UserRepository(CoursesDbContext context) : base(context)
        {
            _context = context;
        }

        // Method to retrieve a user by their refresh token asynchronously
        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            // Retrieve a user by their refresh token and include related Roles and RefreshTokens
            return await _context.Users
                .Include(u => u.Roles)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        // Override of the GetByIdAsync method to include related entities
        public override async Task<User> GetByIdAsync(int Id)
        {
            // Retrieve a user by their ID and include related Instructor entity
            return await _context.Users
                .Where(u => u.Id == Id)
                .Include(u => u.Instructor)
                .FirstOrDefaultAsync();
        }

        // Method to retrieve a user by their username asynchronously
        public async Task<User> GetByUsernameAsync(string username)
        {
            // Retrieve a user by their username and include related Roles and RefreshTokens
            return await _context.Users
                .Include(u => u.Roles)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
