using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Dtos
{
    public class CourseImageDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime UploadDate { get; set; }
    }
}