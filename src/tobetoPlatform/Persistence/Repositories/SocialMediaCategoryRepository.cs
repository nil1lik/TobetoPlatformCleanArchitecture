using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SocialMediaCategoryRepository : EfRepositoryBase<SocialMediaCategory, int, BaseDbContext>, ISocialMediaCategoryRepository
{
    public SocialMediaCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}