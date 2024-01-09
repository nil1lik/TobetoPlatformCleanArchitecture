using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserProfiles;

public class UserProfilesManager : IUserProfilesService
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly UserProfileBusinessRules _userProfileBusinessRules;

    public UserProfilesManager(IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
    {
        _userProfileRepository = userProfileRepository;
        _userProfileBusinessRules = userProfileBusinessRules;
    }

    public async Task<UserProfile?> GetAsync(
        Expression<Func<UserProfile, bool>> predicate,
        Func<IQueryable<UserProfile>, IIncludableQueryable<UserProfile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserProfile? userProfile = await _userProfileRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userProfile;
    }

    public async Task<IPaginate<UserProfile>?> GetListAsync(
        Expression<Func<UserProfile, bool>>? predicate = null,
        Func<IQueryable<UserProfile>, IOrderedQueryable<UserProfile>>? orderBy = null,
        Func<IQueryable<UserProfile>, IIncludableQueryable<UserProfile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserProfile> userProfileList = await _userProfileRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userProfileList;
    }

    public async Task<UserProfile> AddAsync(UserProfile userProfile)
    {
        UserProfile addedUserProfile = await _userProfileRepository.AddAsync(userProfile);

        return addedUserProfile;
    }

    public async Task<UserProfile> UpdateAsync(UserProfile userProfile)
    {
        UserProfile updatedUserProfile = await _userProfileRepository.UpdateAsync(userProfile);

        return updatedUserProfile;
    }

    public async Task<UserProfile> DeleteAsync(UserProfile userProfile, bool permanent = false)
    {
        UserProfile deletedUserProfile = await _userProfileRepository.DeleteAsync(userProfile);

        return deletedUserProfile;
    }
}
