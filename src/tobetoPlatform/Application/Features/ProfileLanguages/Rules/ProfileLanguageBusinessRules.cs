using Application.Features.ProfileLanguages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

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
}