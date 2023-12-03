using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Domain.Entities
{
    public class CourseImage : BaseEntity
    {
        public byte[] Image { get; set; }
        public DateTime UploadDate { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}