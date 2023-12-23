using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileApplicationFormRepository : EfRepositoryBase<ProfileApplicationForm, int, BaseDbContext>, IProfileApplicationFormRepository
{
    public ProfileApplicationFormRepository(BaseDbContext context) : base(context)
    {
    }
}