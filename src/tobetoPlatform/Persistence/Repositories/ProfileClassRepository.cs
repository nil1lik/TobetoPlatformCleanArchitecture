using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileClassRepository : EfRepositoryBase<ProfileClass, int, BaseDbContext>, IProfileClassRepository
{
    public ProfileClassRepository(BaseDbContext context) : base(context)
    {
    }
}