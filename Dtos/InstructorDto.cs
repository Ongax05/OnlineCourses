using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        #nullable enable
        public string? Description { get; set; }
    }
}