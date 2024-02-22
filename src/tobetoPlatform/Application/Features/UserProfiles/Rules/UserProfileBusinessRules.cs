using Application.Features.Exams.Constants;
using Application.Features.UserProfiles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserProfiles.Rules;

public class UserProfileBusinessRules : BaseBusinessRules
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileBusinessRules(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public Task UserProfileShouldExistWhenSelected(UserProfile? userProfile)
    {
        if (userProfile == null)
            throw new BusinessException(UserProfilesBusinessMessages.UserProfileNotExists);
        return Task.CompletedTask;
    }

    public async Task UserProfileIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserProfile? userProfile = await _userProfileRepository.GetAsync(
            predicate: up => up.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserProfileShouldExistWhenSelected(userProfile);
    }

    public async Task UserProfileCannotBeDuplicatedWhenInserted(int id, CancellationToken cancellationToken)
    {
        UserProfile? userProfile = await _userProfileRepository.GetAsync(
            predicate: e => e.UserId == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        if (userProfile != null)
        {
            throw new BusinessException(UserProfilesBusinessMessages.UserProfileExists);
        }
    }
}