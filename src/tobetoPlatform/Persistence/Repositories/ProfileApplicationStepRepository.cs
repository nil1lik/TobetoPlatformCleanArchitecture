using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileApplicationStepRepository : EfRepositoryBase<ProfileApplicationStep, int, BaseDbContext>, IProfileApplicationStepRepository
{
    public ProfileApplicationStepRepository(BaseDbContext context) : base(context)
    {
    }
}