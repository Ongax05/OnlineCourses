using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Percistency.Data
{
    // DbContext class for managing interactions with the underlying database
    public class CoursesDbContext : DbContext
    {
        // Constructor accepting DbContextOptions
        public CoursesDbContext(DbContextOptions opt)
            : base(opt) {}

        // DbSet for managing roles in the database
        public DbSet<Rol> Rols { get; set; }

        // DbSet for managing users in the database
        public DbSet<User> Users { get; set; }

        // DbSet for managing comments in the database
        public DbSet<Comment> Comments { get; set; }

        // DbSet for managing courses in the database
        public DbSet<Course> Courses { get; set; }

        // DbSet for managing instructors in the database
        public DbSet<Instructor> Instructors { get; set; }

        // DbSet for managing qualifications in the database
        public DbSet<Qualification> Qualifications { get; set; }

        // Method for configuring the model using configurations from the current assembly
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class implementation of OnModelCreating
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations defined in the current assembly located in ./Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
