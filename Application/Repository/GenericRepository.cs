using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;
namespace Application.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly CoursesDbContext _context;

    public GenericRepository(CoursesDbContext context)
    {
        _context = context;
    }
    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public virtual async Task<(int totalRegisters, IEnumerable<T> registers)> GetAllAsync (int pageIndex, int pageSize, string Search){
            var totalRegisters = await _context.Set<T>().CountAsync();
            var registers = await _context.Set<T>().Skip((pageIndex -1) * pageSize).Take(pageSize).ToListAsync();
            return (totalRegisters, registers);
        }
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public virtual async Task<T> GetByIdAsync(string id)
    {
       return await _context.Set<T>().FindAsync(id);
    }
    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public virtual void Update(T entity)
    {
        _context.Set<T>()
            .Update(entity);
    }
}
