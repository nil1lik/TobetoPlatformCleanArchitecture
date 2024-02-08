using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoDetailCategories;

public interface IVideoDetailCategoriesService
{
    Task<VideoDetailCategory?> GetAsync(
        Expression<Func<VideoDetailCategory, bool>> predicate,
        Func<IQueryable<VideoDetailCategory>, IIncludableQueryable<VideoDetailCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<VideoDetailCategory>?> GetListAsync(
        Expression<Func<VideoDetailCategory, bool>>? predicate = null,
        Func<IQueryable<VideoDetailCategory>, IOrderedQueryable<VideoDetailCategory>>? orderBy = null,
        Func<IQueryable<VideoDetailCategory>, IIncludableQueryable<VideoDetailCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<VideoDetailCategory> AddAsync(VideoDetailCategory videoDetailCategory);
    Task<VideoDetailCategory> UpdateAsync(VideoDetailCategory videoDetailCategory);
    Task<VideoDetailCategory> DeleteAsync(VideoDetailCategory videoDetailCategory, bool permanent = false);
}
