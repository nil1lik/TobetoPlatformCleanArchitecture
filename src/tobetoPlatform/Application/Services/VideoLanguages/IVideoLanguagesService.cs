using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoLanguages;

public interface IVideoLanguagesService
{
    Task<VideoLanguage?> GetAsync(
        Expression<Func<VideoLanguage, bool>> predicate,
        Func<IQueryable<VideoLanguage>, IIncludableQueryable<VideoLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<VideoLanguage>?> GetListAsync(
        Expression<Func<VideoLanguage, bool>>? predicate = null,
        Func<IQueryable<VideoLanguage>, IOrderedQueryable<VideoLanguage>>? orderBy = null,
        Func<IQueryable<VideoLanguage>, IIncludableQueryable<VideoLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<VideoLanguage> AddAsync(VideoLanguage videoLanguage);
    Task<VideoLanguage> UpdateAsync(VideoLanguage videoLanguage);
    Task<VideoLanguage> DeleteAsync(VideoLanguage videoLanguage, bool permanent = false);
}
