using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileSkills;

public interface IProfileSkillsService
{
    Task<ProfileSkill?> GetAsync(
        Expression<Func<ProfileSkill, bool>> predicate,
        Func<IQueryable<ProfileSkill>, IIncludableQueryable<ProfileSkill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileSkill>?> GetListAsync(
        Expression<Func<ProfileSkill, bool>>? predicate = null,
        Func<IQueryable<ProfileSkill>, IOrderedQueryable<ProfileSkill>>? orderBy = null,
        Func<IQueryable<ProfileSkill>, IIncludableQueryable<ProfileSkill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileSkill> AddAsync(ProfileSkill profileSkill);
    Task<ProfileSkill> UpdateAsync(ProfileSkill profileSkill);
    Task<ProfileSkill> DeleteAsync(ProfileSkill profileSkill, bool permanent = false);
}
