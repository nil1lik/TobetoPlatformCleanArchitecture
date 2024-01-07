using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationAboutCategories;

public interface IEducationAboutCategoriesService
{
    Task<EducationAboutCategory?> GetAsync(
        Expression<Func<EducationAboutCategory, bool>> predicate,
        Func<IQueryable<EducationAboutCategory>, IIncludableQueryable<EducationAboutCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EducationAboutCategory>?> GetListAsync(
        Expression<Func<EducationAboutCategory, bool>>? predicate = null,
        Func<IQueryable<EducationAboutCategory>, IOrderedQueryable<EducationAboutCategory>>? orderBy = null,
        Func<IQueryable<EducationAboutCategory>, IIncludableQueryable<EducationAboutCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EducationAboutCategory> AddAsync(EducationAboutCategory educationAboutCategory);
    Task<EducationAboutCategory> UpdateAsync(EducationAboutCategory educationAboutCategory);
    Task<EducationAboutCategory> DeleteAsync(EducationAboutCategory educationAboutCategory, bool permanent = false);
}
