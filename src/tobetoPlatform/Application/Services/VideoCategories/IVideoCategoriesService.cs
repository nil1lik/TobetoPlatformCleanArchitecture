using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoCategories;

public interface IVideoCategoriesService
{
    Task<VideoCategory?> GetAsync(
        Expression<Func<VideoCategory, bool>> predicate,
        Func<IQueryable<VideoCategory>, IIncludableQueryable<VideoCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<VideoCategory>?> GetListAsync(
        Expression<Func<VideoCategory, bool>>? predicate = null,
        Func<IQueryable<VideoCategory>, IOrderedQueryable<VideoCategory>>? orderBy = null,
        Func<IQueryable<VideoCategory>, IIncludableQueryable<VideoCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<VideoCategory> AddAsync(VideoCategory videoCategory);
    Task<VideoCategory> UpdateAsync(VideoCategory videoCategory);
    Task<VideoCategory> DeleteAsync(VideoCategory videoCategory, bool permanent = false);
}
