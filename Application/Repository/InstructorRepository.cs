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
    public class InstructorRepository : GenericRepository<Instructor>, IInstructor
    {
        private readonly CoursesDbContext context;
        public InstructorRepository(CoursesDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Instructor> GetInstructorByName(string name)
        {
            var register = await context.Instructors.Include(i=>i.User).Where(i=> i.User.Username == name).FirstOrDefaultAsync();
            return register;
        }
    }
}