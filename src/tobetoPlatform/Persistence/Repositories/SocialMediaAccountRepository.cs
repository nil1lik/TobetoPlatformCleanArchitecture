using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SocialMediaAccountRepository : EfRepositoryBase<SocialMediaAccount, int, BaseDbContext>, ISocialMediaAccountRepository
{
    public SocialMediaAccountRepository(BaseDbContext context) : base(context)
    {
    }
}