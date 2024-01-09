using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserProfileRepository : EfRepositoryBase<UserProfile, int, BaseDbContext>, IUserProfileRepository
{
    public UserProfileRepository(BaseDbContext context) : base(context)
    {
    }
}