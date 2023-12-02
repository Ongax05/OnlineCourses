using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseImage : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public byte[] Image { get; set; }
        public DateTime UploadDate { get; set; }
    }
}