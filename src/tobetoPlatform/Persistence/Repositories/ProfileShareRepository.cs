using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileShareRepository : EfRepositoryBase<ProfileShare, int, BaseDbContext>, IProfileShareRepository
{
    public ProfileShareRepository(BaseDbContext context) : base(context)
    {
    }
}