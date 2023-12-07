using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IQualification : IGenericRepository<Qualification>
    {
        Task UpdateCourseAverage (int CourseId);
        Task<IEnumerable<Qualification>> GetQualificationsByCourse (int CourseId);
        Task<IEnumerable<Qualification>> GetQualificationsByUser (int UserId);
    }
}