using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileLanguages;

public interface IProfileLanguagesService
{
    Task<ProfileLanguage?> GetAsync(
        Expression<Func<ProfileLanguage, bool>> predicate,
        Func<IQueryable<ProfileLanguage>, IIncludableQueryable<ProfileLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileLanguage>?> GetListAsync(
        Expression<Func<ProfileLanguage, bool>>? predicate = null,
        Func<IQueryable<ProfileLanguage>, IOrderedQueryable<ProfileLanguage>>? orderBy = null,
        Func<IQueryable<ProfileLanguage>, IIncludableQueryable<ProfileLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileLanguage> AddAsync(ProfileLanguage profileLanguage);
    Task<ProfileLanguage> UpdateAsync(ProfileLanguage profileLanguage);
    Task<ProfileLanguage> DeleteAsync(ProfileLanguage profileLanguage, bool permanent = false);
}
