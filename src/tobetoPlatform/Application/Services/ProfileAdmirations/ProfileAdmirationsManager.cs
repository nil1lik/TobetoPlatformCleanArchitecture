using Application.Features.ProfileAdmirations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileAdmirations;

public class ProfileAdmirationsManager : IProfileAdmirationsService
{
    private readonly IProfileAdmirationRepository _profileAdmirationRepository;
    private readonly ProfileAdmirationBusinessRules _profileAdmirationBusinessRules;

    public ProfileAdmirationsManager(IProfileAdmirationRepository profileAdmirationRepository, ProfileAdmirationBusinessRules profileAdmirationBusinessRules)
    {
        _profileAdmirationRepository = profileAdmirationRepository;
        _profileAdmirationBusinessRules = profileAdmirationBusinessRules;
    }

    public async Task<ProfileAdmiration?> GetAsync(
        Expression<Func<ProfileAdmiration, bool>> predicate,
        Func<IQueryable<ProfileAdmiration>, IIncludableQueryable<ProfileAdmiration, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileAdmiration? profileAdmiration = await _profileAdmirationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileAdmiration;
    }

    public async Task<IPaginate<ProfileAdmiration>?> GetListAsync(
        Expression<Func<ProfileAdmiration, bool>>? predicate = null,
        Func<IQueryable<ProfileAdmiration>, IOrderedQueryable<ProfileAdmiration>>? orderBy = null,
        Func<IQueryable<ProfileAdmiration>, IIncludableQueryable<ProfileAdmiration, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileAdmiration> profileAdmirationList = await _profileAdmirationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileAdmirationList;
    }

    public async Task<ProfileAdmiration> AddAsync(ProfileAdmiration profileAdmiration)
    {
        ProfileAdmiration addedProfileAdmiration = await _profileAdmirationRepository.AddAsync(profileAdmiration);

        return addedProfileAdmiration;
    }

    public async Task<ProfileAdmiration> UpdateAsync(ProfileAdmiration profileAdmiration)
    {
        ProfileAdmiration updatedProfileAdmiration = await _profileAdmirationRepository.UpdateAsync(profileAdmiration);

        return updatedProfileAdmiration;
    }

    public async Task<ProfileAdmiration> DeleteAsync(ProfileAdmiration profileAdmiration, bool permanent = false)
    {
        ProfileAdmiration deletedProfileAdmiration = await _profileAdmirationRepository.DeleteAsync(profileAdmiration);

        return deletedProfileAdmiration;
    }
}
