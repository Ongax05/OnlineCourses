using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string Name { get; set;}
        #nullable enable
        public string? Description { get; set; }
    }
}