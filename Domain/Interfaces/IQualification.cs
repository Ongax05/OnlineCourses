using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IQualification
    {
        Task<Qualification> GetByIdsAsync(int courseId, int UserId);
        Task<IEnumerable<Qualification>> GetAllAsync();
        IEnumerable<Qualification> Find(Expression<Func<Qualification, bool>> expression);
        void Add(Qualification entity);
        void Remove(Qualification entity);
        void Update(Qualification entity);
    }
}