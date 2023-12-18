using Application.Features.LanguageLevels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LanguageLevels.Rules;

public class LanguageLevelBusinessRules : BaseBusinessRules
{
    private readonly ILanguageLevelRepository _languageLevelRepository;

    public LanguageLevelBusinessRules(ILanguageLevelRepository languageLevelRepository)
    {
        _languageLevelRepository = languageLevelRepository;
    }

    public Task LanguageLevelShouldExistWhenSelected(LanguageLevel? languageLevel)
    {
        if (languageLevel == null)
            throw new BusinessException(LanguageLevelsBusinessMessages.LanguageLevelNotExists);
        return Task.CompletedTask;
    }

    public async Task LanguageLevelIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LanguageLevel? languageLevel = await _languageLevelRepository.GetAsync(
            predicate: ll => ll.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LanguageLevelShouldExistWhenSelected(languageLevel);
    }
}