using Application.Features.LanguageLevels.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LanguageLevels;

public class LanguageLevelsManager : ILanguageLevelsService
{
    private readonly ILanguageLevelRepository _languageLevelRepository;
    private readonly LanguageLevelBusinessRules _languageLevelBusinessRules;

    public LanguageLevelsManager(ILanguageLevelRepository languageLevelRepository, LanguageLevelBusinessRules languageLevelBusinessRules)
    {
        _languageLevelRepository = languageLevelRepository;
        _languageLevelBusinessRules = languageLevelBusinessRules;
    }

    public async Task<LanguageLevel?> GetAsync(
        Expression<Func<LanguageLevel, bool>> predicate,
        Func<IQueryable<LanguageLevel>, IIncludableQueryable<LanguageLevel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LanguageLevel? languageLevel = await _languageLevelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return languageLevel;
    }

    public async Task<IPaginate<LanguageLevel>?> GetListAsync(
        Expression<Func<LanguageLevel, bool>>? predicate = null,
        Func<IQueryable<LanguageLevel>, IOrderedQueryable<LanguageLevel>>? orderBy = null,
        Func<IQueryable<LanguageLevel>, IIncludableQueryable<LanguageLevel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LanguageLevel> languageLevelList = await _languageLevelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return languageLevelList;
    }

    public async Task<LanguageLevel> AddAsync(LanguageLevel languageLevel)
    {
        LanguageLevel addedLanguageLevel = await _languageLevelRepository.AddAsync(languageLevel);

        return addedLanguageLevel;
    }

    public async Task<LanguageLevel> UpdateAsync(LanguageLevel languageLevel)
    {
        LanguageLevel updatedLanguageLevel = await _languageLevelRepository.UpdateAsync(languageLevel);

        return updatedLanguageLevel;
    }

    public async Task<LanguageLevel> DeleteAsync(LanguageLevel languageLevel, bool permanent = false)
    {
        LanguageLevel deletedLanguageLevel = await _languageLevelRepository.DeleteAsync(languageLevel);

        return deletedLanguageLevel;
    }
}
