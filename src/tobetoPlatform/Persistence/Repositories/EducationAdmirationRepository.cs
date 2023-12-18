using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EducationAdmirationRepository : EfRepositoryBase<EducationAdmiration, int, BaseDbContext>, IEducationAdmirationRepository
{
    public EducationAdmirationRepository(BaseDbContext context) : base(context)
    {
    }
}