using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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
    }
}