using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;

namespace Application.Repository
{
    // Generic repository class implementing the IGenericRepository interface
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // DbContext to interact with the database
        private readonly CoursesDbContext _context;

        // Constructor to initialize the repository with a DbContext
        public GenericRepository(CoursesDbContext context)
        {
            _context = context;
        }

        // Method to add a single entity to the repository
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        // Method to find entities based on a specified expression
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        // Method to retrieve all entities asynchronously
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        // Method to retrieve an entity by its integer ID asynchronously
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        // Method to remove a single entity from the repository
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        // Method to update an entity in the repository
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
