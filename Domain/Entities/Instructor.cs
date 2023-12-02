using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor :BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        #nullable enable
        public string? Description { get; set; }
        #nullable disable
        public ICollection<Course> Courses { get; set; }
    }
}