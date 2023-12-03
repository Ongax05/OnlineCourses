using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CourseImageId { get; set; }
        public int InstructorId { get; set; }
        public float AverageRating { get; set; }
    }
}