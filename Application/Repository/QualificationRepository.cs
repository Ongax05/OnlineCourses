using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;

namespace Application.Repository
{
    public class QualificationRepository : IQualification
    {
        private readonly CoursesDbContext context;
        public QualificationRepository (CoursesDbContext context)
        {
            this.context = context;
        }
        public void Add(Qualification entity)
        {
            context.Set<Qualification>().Add(entity);
        }

        public IEnumerable<Qualification> Find(Expression<Func<Qualification, bool>> expression)
        {
            return context.Set<Qualification>().Where(expression);
        }

        public async Task<IEnumerable<Qualification>> GetAllAsync()
        {
            return await context.Set<Qualification>().ToListAsync();
        }

        public async Task<Qualification> GetByIdsAsync(int courseId, int UserId)
        {
            
            return await context.Set<Qualification>().Where(c=> c.CourseId == courseId && c.UserId == UserId).FirstAsync();
        }

        public void Remove(Qualification entity)
        {
            context.Set<Qualification>().Remove(entity);
        }

        public void Update(Qualification entity)
        {
            context.Set<Qualification>().Update(entity);
        }
    }
}