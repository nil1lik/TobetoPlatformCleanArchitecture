using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileSkillRepository : EfRepositoryBase<ProfileSkill, int, BaseDbContext>, IProfileSkillRepository
{
    public ProfileSkillRepository(BaseDbContext context) : base(context)
    {
    }
}