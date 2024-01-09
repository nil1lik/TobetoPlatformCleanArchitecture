using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserApplicationRepository : EfRepositoryBase<UserApplication, int, BaseDbContext>, IUserApplicationRepository
{
    public UserApplicationRepository(BaseDbContext context) : base(context)
    {
    }
}