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

        public async Task UpdateCourseAverage(int CourseId)
        {
            var Course = await context
                .Courses
                .Where(c=>c.Id == CourseId)
                .FirstOrDefaultAsync();
             Console.WriteLine(Course.Qualifications.Average(q=>q.CourseQualification));
             Course.AverageRating = Course.Qualifications.Average(q=>q.CourseQualification);
        }
    }
}
