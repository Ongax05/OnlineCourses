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
    // Repository class for handling courses, inheriting from the GenericRepository<Course> class and implementing ICourse interface
    public class CourseRepository : GenericRepository<Course>, ICourse
    {
        // Private field to store the instance of CoursesDbContext
        private readonly CoursesDbContext context;

        // Constructor to initialize the repository with a CoursesDbContext
        public CourseRepository(CoursesDbContext context) : base(context)
        {
            this.context = context;
        }

        // Override of the GetByIdAsync method to include related entities
        public override async Task<Course> GetByIdAsync(int id)
        {
            // Retrieve a course by its ID and include related entities like Instructor and User
            var register = await context
                .Courses
                .Where(c => c.Id == id)
                .Include(c => c.Instructor)
                    .ThenInclude(i => i.User)
                .FirstOrDefaultAsync();

            // Return the retrieved course
            return register;
        }
    }
}
