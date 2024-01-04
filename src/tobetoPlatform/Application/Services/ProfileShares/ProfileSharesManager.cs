using Application.Features.ProfileShares.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileShares;

public class ProfileSharesManager : IProfileSharesService
{
    private readonly IProfileShareRepository _profileShareRepository;
    private readonly ProfileShareBusinessRules _profileShareBusinessRules;

    public ProfileSharesManager(IProfileShareRepository profileShareRepository, ProfileShareBusinessRules profileShareBusinessRules)
    {
        _profileShareRepository = profileShareRepository;
        _profileShareBusinessRules = profileShareBusinessRules;
    }

    public async Task<ProfileShare?> GetAsync(
        Expression<Func<ProfileShare, bool>> predicate,
        Func<IQueryable<ProfileShare>, IIncludableQueryable<ProfileShare, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileShare? profileShare = await _profileShareRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileShare;
    }

    public async Task<IPaginate<ProfileShare>?> GetListAsync(
        Expression<Func<ProfileShare, bool>>? predicate = null,
        Func<IQueryable<ProfileShare>, IOrderedQueryable<ProfileShare>>? orderBy = null,
        Func<IQueryable<ProfileShare>, IIncludableQueryable<ProfileShare, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileShare> profileShareList = await _profileShareRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileShareList;
    }

    public async Task<ProfileShare> AddAsync(ProfileShare profileShare)
    {
        ProfileShare addedProfileShare = await _profileShareRepository.AddAsync(profileShare);

        return addedProfileShare;
    }

    public async Task<ProfileShare> UpdateAsync(ProfileShare profileShare)
    {
        ProfileShare updatedProfileShare = await _profileShareRepository.UpdateAsync(profileShare);

        return updatedProfileShare;
    }

    public async Task<ProfileShare> DeleteAsync(ProfileShare profileShare, bool permanent = false)
    {
        ProfileShare deletedProfileShare = await _profileShareRepository.DeleteAsync(profileShare);

        return deletedProfileShare;
    }
}
