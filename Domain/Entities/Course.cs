using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public float AverageRating { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Qualification> Qualifications { get; set; }
    }
}
