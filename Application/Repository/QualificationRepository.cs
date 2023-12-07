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
    public class QualificationRepository : GenericRepository<Qualification>, IQualification
    {
        private readonly CoursesDbContext context;

        public QualificationRepository(CoursesDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Qualification>> GetQualificationsByCourse(int CourseId)
        {
            var Qualifications = await context.Qualifications.Where(q=>q.CourseId == CourseId).ToListAsync();
            return Qualifications;
        }

        public async Task<IEnumerable<Qualification>> GetQualificationsByUser(int UserId)
        {
            var Qualifications = await context.Qualifications.Where(q=>q.UserId == UserId).ToListAsync();
            return Qualifications;
        }

        public async Task UpdateCourseAverage(int CourseId)
        {
            var Course = await context
                .Courses
                .Include(c=>c.Qualifications)
                .Where(c=>c.Id == CourseId)
                .FirstOrDefaultAsync();
            Course.AverageRating = Course.Qualifications.Average(q=>q.CourseQualification);
            Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{Course.AverageRating}");
            await context.SaveChangesAsync();
        }
    }
}
