using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;

namespace Application.Repository
{
    // Repository class for handling instructors, inheriting from the GenericRepository<Instructor> class and implementing IInstructor interface
    public class InstructorRepository : GenericRepository<Instructor>, IInstructor
    {
        // Private field to store the instance of CoursesDbContext
        private readonly CoursesDbContext context;

        // Constructor to initialize the repository with a CoursesDbContext
        public InstructorRepository(CoursesDbContext context) : base(context)
        {
            this.context = context;
        }

        // Method to retrieve an instructor by their username asynchronously
        public async Task<Instructor> GetInstructorByName(string name)
        {
            // Retrieve an instructor by their username and include related User entity
            var register = await context.Instructors.Include(i => i.User).Where(i => i.User.Username == name).FirstOrDefaultAsync();

            // Return the retrieved instructor
            return register;
        }
    }
}
