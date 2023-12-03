using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IComment
    {
        Task<Comment> GetByIdsAsync(int courseId, int UserId);
        Task<IEnumerable<Comment>> GetAllAsync();
        IEnumerable<Comment> Find(Expression<Func<Comment, bool>> expression);
        void Add(Comment entity);
        void Remove(Comment entity);
        void Update(Comment entity);
    }
}