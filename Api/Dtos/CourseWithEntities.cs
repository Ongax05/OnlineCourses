using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class CourseWithEntities
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int InstructorId { get; set; }
        public InstructorDto Instructor { get; set; }
        public float AverageRating { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<QualificationDto> Qualifications { get; set; }
    }
}