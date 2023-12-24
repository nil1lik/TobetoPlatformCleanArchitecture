using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileApplicationRepository : EfRepositoryBase<ProfileApplication, int, BaseDbContext>, IProfileApplicationRepository
{
    public ProfileApplicationRepository(BaseDbContext context) : base(context)
    {
    }
}