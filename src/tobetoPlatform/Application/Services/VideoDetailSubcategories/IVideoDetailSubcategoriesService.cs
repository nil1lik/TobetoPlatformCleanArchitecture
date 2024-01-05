using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoDetailSubcategories;

public interface IVideoDetailSubcategoriesService
{
    Task<VideoDetailSubcategory?> GetAsync(
        Expression<Func<VideoDetailSubcategory, bool>> predicate,
        Func<IQueryable<VideoDetailSubcategory>, IIncludableQueryable<VideoDetailSubcategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<VideoDetailSubcategory>?> GetListAsync(
        Expression<Func<VideoDetailSubcategory, bool>>? predicate = null,
        Func<IQueryable<VideoDetailSubcategory>, IOrderedQueryable<VideoDetailSubcategory>>? orderBy = null,
        Func<IQueryable<VideoDetailSubcategory>, IIncludableQueryable<VideoDetailSubcategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<VideoDetailSubcategory> AddAsync(VideoDetailSubcategory videoDetailSubcategory);
    Task<VideoDetailSubcategory> UpdateAsync(VideoDetailSubcategory videoDetailSubcategory);
    Task<VideoDetailSubcategory> DeleteAsync(VideoDetailSubcategory videoDetailSubcategory, bool permanent = false);
}
