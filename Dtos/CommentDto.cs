using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class CommentDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string CourseComment { get; set; }
    }
}