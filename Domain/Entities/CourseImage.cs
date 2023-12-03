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
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [DataType(DataType.Upload)]
        [SwaggerSchema(Format = "byte", Title = "ImageData")]
        public byte[] Image { get; set; }
        public DateTime UploadDate { get; set; }
    }
}