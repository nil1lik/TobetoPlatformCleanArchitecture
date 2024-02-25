using Application.Features.ProfileLanguages.Constants;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;

namespace Application.Features.ProfileLanguages.Rules;

public class ProfileLanguageBusinessRules : BaseBusinessRules
{
    private readonly IProfileLanguageRepository _profileLanguageRepository;

    public ProfileLanguageBusinessRules(IProfileLanguageRepository profileLanguageRepository)
    {
        _profileLanguageRepository = profileLanguageRepository;
    }

    public Task ProfileLanguageShouldExistWhenSelected(ProfileLanguage? profileLanguage)
    {
        if (profileLanguage == null)
            throw new BusinessException(ProfileLanguagesBusinessMessages.ProfileLanguageNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileLanguageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileLanguage? profileLanguage = await _profileLanguageRepository.GetAsync(
            predicate: pl => pl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileLanguageShouldExistWhenSelected(profileLanguage);
    }

    public async Task ProfileLanguageCannotBeDuplicateWhenInserted(int id, int userProfileId, CancellationToken cancellationToken)
    {
        bool isDuplicate = await _profileLanguageRepository.AnyAsync(
            predicate: e => e.Language.Id == id && e.UserProfile.Id == userProfileId,
            cancellationToken: cancellationToken
        );

        if (isDuplicate)
        {
            throw new BusinessException(ProfileLanguagesBusinessMessages.ProfileLanguageConnotBeDuplicateWhenInserted);
        }
    }

}