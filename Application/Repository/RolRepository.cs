using Domain.Entities;
using Domain.Interfaces;
using Percistency.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly CoursesDbContext _context;

    public RolRepository(CoursesDbContext context) : base(context)
    {
       _context = context;
    }
}
