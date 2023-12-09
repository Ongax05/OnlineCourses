using Domain.Entities;
using Domain.Interfaces;
using Percistency.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    public RolRepository(CoursesDbContext context)
        : base(context) {}
}
