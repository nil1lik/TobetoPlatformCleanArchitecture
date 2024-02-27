using Application.Features.ProfileClasses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileClasses;

public class ProfileClassesManager : IProfileClassesService
{
    private readonly IProfileClassRepository _profileClassRepository;
    private readonly ProfileClassBusinessRules _profileClassBusinessRules;

    public ProfileClassesManager(IProfileClassRepository profileClassRepository, ProfileClassBusinessRules profileClassBusinessRules)
    {
        _profileClassRepository = profileClassRepository;
        _profileClassBusinessRules = profileClassBusinessRules;
    }

    public async Task<ProfileClass?> GetAsync(
        Expression<Func<ProfileClass, bool>> predicate,
        Func<IQueryable<ProfileClass>, IIncludableQueryable<ProfileClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileClass? profileClass = await _profileClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileClass;
    }

    public async Task<IPaginate<ProfileClass>?> GetListAsync(
        Expression<Func<ProfileClass, bool>>? predicate = null,
        Func<IQueryable<ProfileClass>, IOrderedQueryable<ProfileClass>>? orderBy = null,
        Func<IQueryable<ProfileClass>, IIncludableQueryable<ProfileClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileClass> profileClassList = await _profileClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileClassList;
    }

    public async Task<ProfileClass> AddAsync(ProfileClass profileClass)
    {
        ProfileClass addedProfileClass = await _profileClassRepository.AddAsync(profileClass);

        return addedProfileClass;
    }

    public async Task<ProfileClass> UpdateAsync(ProfileClass profileClass)
    {
        ProfileClass updatedProfileClass = await _profileClassRepository.UpdateAsync(profileClass);

        return updatedProfileClass;
    }

    public async Task<ProfileClass> DeleteAsync(ProfileClass profileClass, bool permanent = false)
    {
        ProfileClass deletedProfileClass = await _profileClassRepository.DeleteAsync(profileClass);

        return deletedProfileClass;
    }
}
