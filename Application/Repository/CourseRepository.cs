using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Percistency.Data;

namespace Application.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourse
    {
        private readonly CoursesDbContext context;
        public CourseRepository(CoursesDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}