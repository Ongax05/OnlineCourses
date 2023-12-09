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
    // Repository class for handling qualifications, inheriting from the GenericRepository<Qualification> class and implementing IQualification interface
    public class QualificationRepository : GenericRepository<Qualification>, IQualification
    {
        // Private field to store the instance of CoursesDbContext
        private readonly CoursesDbContext context;

        // Constructor to initialize the repository with a CoursesDbContext
        public QualificationRepository(CoursesDbContext context) : base(context)
        {
            this.context = context;
        }

        // Method to retrieve the average qualification for a specific course asynchronously
        public async Task<double> GetAverageQualificationByCourse(int CourseId)
        {
            // Retrieve and calculate the average qualification for a specific course
            var Qualifications = await context.Qualifications.Where(q => q.CourseId == CourseId).AverageAsync(q => q.CourseQualification);
            return Qualifications;
        }

        // Method to retrieve qualifications for a specific user asynchronously
        public async Task<List<Qualification>> GetQualificationsByUser(int UserId)
        {
            // Retrieve qualifications for a specific user
            var Qualifications = await context.Qualifications.Where(q => q.UserId == UserId).ToListAsync();
            return Qualifications;
        }

        // Method to update the average rating for a specific course asynchronously
        public async Task UpdateCourseAverage(int CourseId)
        {
            // Retrieve the course and related qualifications
            var Course = await context
                .Courses
                .Include(c => c.Qualifications)
                .Where(c => c.Id == CourseId)
                .FirstOrDefaultAsync();

            // Calculate and update the average rating for the course
            Course.AverageRating = Course.Qualifications.Average(q => q.CourseQualification);

            // Save changes to the database
            await context.SaveChangesAsync();
        }
    }
}
