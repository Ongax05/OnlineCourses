using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInstructor : IGenericRepository<Instructor>
    {
        Task<Instructor> GetInstructorByName(string name);
    }
}