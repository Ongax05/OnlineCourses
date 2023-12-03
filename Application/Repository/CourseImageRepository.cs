using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Percistency.Data;

namespace Application.Repository
{
    public class CourseImageRepository : GenericRepository<CourseImage>, ICourseImage
    {
        private readonly CoursesDbContext context;
        public CourseImageRepository(CoursesDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}