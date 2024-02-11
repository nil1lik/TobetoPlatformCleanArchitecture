using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileSkillRepository : IAsyncRepository<ProfileSkill, int>, IRepository<ProfileSkill, int>
{
}