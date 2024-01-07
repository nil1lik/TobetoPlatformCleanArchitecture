using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GraduationRepository : EfRepositoryBase<Graduation, int, BaseDbContext>, IGraduationRepository
{
    public GraduationRepository(BaseDbContext context) : base(context)
    {
    }
}