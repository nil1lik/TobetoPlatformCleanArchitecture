using Application.Features.Languages.Constants;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Rules;

public class LanguageBusinessRules : BaseBusinessRules
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageBusinessRules(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public Task LanguageShouldExistWhenSelected(Language? language)
    {
        if (language == null)
            throw new BusinessException(LanguagesBusinessMessages.LanguageNotExists);
        return Task.CompletedTask;
    }

    public async Task LanguageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Language? language = await _languageRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LanguageShouldExistWhenSelected(language);
    }

    public async Task LanguageShouldNotBeTheSame(string name, Language? language)
    {
        IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);

        if (result.Items.Any() && language != null && language.Name == result.Items.First().Name)
        {
            throw new BusinessException(LanguagesBusinessMessages.LanguageShouldNotBeTheSame);
        }
    }
}