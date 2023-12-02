using System.Linq.Expressions;
using Domain.Entities;
namespace Domain.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
}
