using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Percistency.Data;

namespace Application.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourse
    {
        private readonly CoursesDbContext context;

        public CourseRepository(CoursesDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public override async Task<Course> GetByIdAsync(int id)
        {
            var register = await context
                .Courses
                .Where(c => c.Id == id)
                .Include(c => c.Comments)
                .Include(c => c.Qualifications)
                .FirstOrDefaultAsync();
            return register;
        }
    }
}
