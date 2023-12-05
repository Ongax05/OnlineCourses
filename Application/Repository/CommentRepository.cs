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
    public class CommentRepository : GenericRepository<Comment>, IComment
    {
        private readonly CoursesDbContext context;
        public CommentRepository(CoursesDbContext context) : base (context) => this.context = context;

    }
}