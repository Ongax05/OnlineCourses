using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Percistency.Data;

namespace Application.Repository
{
    // Repository class for handling comments, inheriting from the GenericRepository<Comment> class and implementing IComment interface
    public class CommentRepository : GenericRepository<Comment>, IComment
    {
        // Private field to store the instance of CoursesDbContext
        private readonly CoursesDbContext context;

        // Constructor to initialize the repository with a CoursesDbContext
        public CommentRepository(CoursesDbContext context) : base(context) => this.context = context;

        // Method to retrieve comments for a specific course asynchronously
        public async Task<IEnumerable<Comment>> GetCommentsByCourse(int CourseId)
        {
            // Retrieve comments from the context where the CourseId matches the specified value
            var Comments = await context.Comments.Where(c => c.CourseId == CourseId).ToListAsync();
            return Comments;
        }

        // Method to retrieve comments for a specific user asynchronously
        public async Task<IEnumerable<Comment>> GetCommentsByUser(int UserId)
        {
            // Retrieve comments from the context where the UserId matches the specified value
            var Comments = await context.Comments.Where(c => c.UserId == UserId).ToListAsync();
            return Comments;
        }
    }
}
