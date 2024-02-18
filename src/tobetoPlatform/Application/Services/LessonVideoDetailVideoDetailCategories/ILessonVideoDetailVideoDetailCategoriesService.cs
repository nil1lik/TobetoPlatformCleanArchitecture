using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonVideoDetailVideoDetailCategories;

public interface ILessonVideoDetailVideoDetailCategoriesService
{
    Task<LessonVideoDetailVideoDetailCategory?> GetAsync(
        Expression<Func<LessonVideoDetailVideoDetailCategory, bool>> predicate,
        Func<IQueryable<LessonVideoDetailVideoDetailCategory>, IIncludableQueryable<LessonVideoDetailVideoDetailCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonVideoDetailVideoDetailCategory>?> GetListAsync(
        Expression<Func<LessonVideoDetailVideoDetailCategory, bool>>? predicate = null,
        Func<IQueryable<LessonVideoDetailVideoDetailCategory>, IOrderedQueryable<LessonVideoDetailVideoDetailCategory>>? orderBy = null,
        Func<IQueryable<LessonVideoDetailVideoDetailCategory>, IIncludableQueryable<LessonVideoDetailVideoDetailCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonVideoDetailVideoDetailCategory> AddAsync(LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory);
    Task<LessonVideoDetailVideoDetailCategory> UpdateAsync(LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory);
    Task<LessonVideoDetailVideoDetailCategory> DeleteAsync(LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory, bool permanent = false);
}
