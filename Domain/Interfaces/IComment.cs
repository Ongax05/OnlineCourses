using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IComment : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByCourse (int CourseId);
        Task<IEnumerable<Comment>> GetCommentsByUser (int UserId);
    }
}