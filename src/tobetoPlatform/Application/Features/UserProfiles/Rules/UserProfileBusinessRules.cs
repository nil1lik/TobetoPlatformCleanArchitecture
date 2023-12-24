using Application.Features.EducationAdmirations.Constants;
using Application.Features.UserProfiles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserProfiles.Rules;

public class UserProfileBusinessRules : BaseBusinessRules
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IEducationAdmirationRepository _educationAdmirationRepository;
    private readonly IEducationAboutRepository _educationAboutRepository;


    public UserProfileBusinessRules(IUserProfileRepository userProfileRepository, IEducationAdmirationRepository educationAdmirationRepository,
        IEducationAboutRepository educationAboutRepository)
    {
        _userProfileRepository = userProfileRepository;
        _educationAboutRepository = educationAboutRepository;
        _educationAdmirationRepository = educationAdmirationRepository;
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

    public async Task CheckUnwatchedVideosOnEducationPath(int userProfileId, CancellationToken cancellationToken)
    {
        EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(
            predicate: ea => ea.Id == userProfileId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(
            predicate: ea => ea.Id == userProfileId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (educationAdmiration.CompletionRate == 0)
        {
            throw new BusinessException(educationAbout.EndDate + EducationAdmirationsBusinessMessages.NoVideoWatched);
        }
    }
}