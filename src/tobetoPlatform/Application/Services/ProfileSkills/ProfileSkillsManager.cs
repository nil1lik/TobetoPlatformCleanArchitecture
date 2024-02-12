using Application.Features.ProfileSkills.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileSkills;

public class ProfileSkillsManager : IProfileSkillsService
{
    private readonly IProfileSkillRepository _profileSkillRepository;
    private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

    public ProfileSkillsManager(IProfileSkillRepository profileSkillRepository, ProfileSkillBusinessRules profileSkillBusinessRules)
    {
        _profileSkillRepository = profileSkillRepository;
        _profileSkillBusinessRules = profileSkillBusinessRules;
    }

    public async Task<ProfileSkill?> GetAsync(
        Expression<Func<ProfileSkill, bool>> predicate,
        Func<IQueryable<ProfileSkill>, IIncludableQueryable<ProfileSkill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileSkill;
    }

    public async Task<IPaginate<ProfileSkill>?> GetListAsync(
        Expression<Func<ProfileSkill, bool>>? predicate = null,
        Func<IQueryable<ProfileSkill>, IOrderedQueryable<ProfileSkill>>? orderBy = null,
        Func<IQueryable<ProfileSkill>, IIncludableQueryable<ProfileSkill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileSkill> profileSkillList = await _profileSkillRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileSkillList;
    }

    public async Task<ProfileSkill> AddAsync(ProfileSkill profileSkill)
    {
        ProfileSkill addedProfileSkill = await _profileSkillRepository.AddAsync(profileSkill);

        return addedProfileSkill;
    }

    public async Task<ProfileSkill> UpdateAsync(ProfileSkill profileSkill)
    {
        ProfileSkill updatedProfileSkill = await _profileSkillRepository.UpdateAsync(profileSkill);

        return updatedProfileSkill;
    }

    public async Task<ProfileSkill> DeleteAsync(ProfileSkill profileSkill, bool permanent = false)
    {
        ProfileSkill deletedProfileSkill = await _profileSkillRepository.DeleteAsync(profileSkill);

        return deletedProfileSkill;
    }
}
