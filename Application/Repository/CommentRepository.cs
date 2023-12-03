using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Percistency.Data;

namespace Application.Repository
{
    public class CommentRepository : IComment
    {
        private readonly CoursesDbContext context;
        public CommentRepository (CoursesDbContext context)
        {
            this.context = context;
        }
        public void Add(Comment entity)
        {
            context.Set<Comment>().Add(entity);
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> expression)
        {
            return context.Set<Comment>().Where(expression);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await context.Set<Comment>().ToListAsync();
        }

        public async Task<Comment> GetByIdsAsync(int courseId, int UserId)
        {
            
            return await context.Set<Comment>().Where(c=> c.CourseId == courseId && c.UserId == UserId).FirstAsync();
        }

        public void Remove(Comment entity)
        {
            context.Set<Comment>().Remove(entity);
        }

        public void Update(Comment entity)
        {
            context.Set<Comment>().Update(entity);
        }
    }
}