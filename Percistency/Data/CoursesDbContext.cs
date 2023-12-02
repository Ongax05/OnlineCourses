using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Percistency.Data
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions opt)
            : base(opt) {}

        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public int MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Comment>().HasKey(c=> new {c.CourseId, c.UserId});
            modelBuilder.Entity<Qualification>().HasKey(q=> new {q.CourseId, q.UserId});
        }

    }
}
