using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class QualificationDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public float CourseQualification {get; set;}
    }
}