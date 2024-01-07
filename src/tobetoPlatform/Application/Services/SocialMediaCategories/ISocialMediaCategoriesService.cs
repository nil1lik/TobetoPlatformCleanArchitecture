using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialMediaCategories;

public interface ISocialMediaCategoriesService
{
    Task<SocialMediaCategory?> GetAsync(
        Expression<Func<SocialMediaCategory, bool>> predicate,
        Func<IQueryable<SocialMediaCategory>, IIncludableQueryable<SocialMediaCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SocialMediaCategory>?> GetListAsync(
        Expression<Func<SocialMediaCategory, bool>>? predicate = null,
        Func<IQueryable<SocialMediaCategory>, IOrderedQueryable<SocialMediaCategory>>? orderBy = null,
        Func<IQueryable<SocialMediaCategory>, IIncludableQueryable<SocialMediaCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SocialMediaCategory> AddAsync(SocialMediaCategory socialMediaCategory);
    Task<SocialMediaCategory> UpdateAsync(SocialMediaCategory socialMediaCategory);
    Task<SocialMediaCategory> DeleteAsync(SocialMediaCategory socialMediaCategory, bool permanent = false);
}
