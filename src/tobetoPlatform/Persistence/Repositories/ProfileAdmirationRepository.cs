using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileAdmirationRepository : EfRepositoryBase<ProfileAdmiration, int, BaseDbContext>, IProfileAdmirationRepository
{
    public ProfileAdmirationRepository(BaseDbContext context) : base(context)
    {
    }
}