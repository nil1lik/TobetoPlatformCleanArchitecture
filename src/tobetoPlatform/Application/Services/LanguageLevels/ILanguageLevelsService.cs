using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LanguageLevels;

public interface ILanguageLevelsService
{
    Task<LanguageLevel?> GetAsync(
        Expression<Func<LanguageLevel, bool>> predicate,
        Func<IQueryable<LanguageLevel>, IIncludableQueryable<LanguageLevel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LanguageLevel>?> GetListAsync(
        Expression<Func<LanguageLevel, bool>>? predicate = null,
        Func<IQueryable<LanguageLevel>, IOrderedQueryable<LanguageLevel>>? orderBy = null,
        Func<IQueryable<LanguageLevel>, IIncludableQueryable<LanguageLevel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LanguageLevel> AddAsync(LanguageLevel languageLevel);
    Task<LanguageLevel> UpdateAsync(LanguageLevel languageLevel);
    Task<LanguageLevel> DeleteAsync(LanguageLevel languageLevel, bool permanent = false);
}
