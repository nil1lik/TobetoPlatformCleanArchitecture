using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonVideoDetails;

public interface ILessonVideoDetailsService
{
    Task<LessonVideoDetail?> GetAsync(
        Expression<Func<LessonVideoDetail, bool>> predicate,
        Func<IQueryable<LessonVideoDetail>, IIncludableQueryable<LessonVideoDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonVideoDetail>?> GetListAsync(
        Expression<Func<LessonVideoDetail, bool>>? predicate = null,
        Func<IQueryable<LessonVideoDetail>, IOrderedQueryable<LessonVideoDetail>>? orderBy = null,
        Func<IQueryable<LessonVideoDetail>, IIncludableQueryable<LessonVideoDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonVideoDetail> AddAsync(LessonVideoDetail lessonVideoDetail);
    Task<LessonVideoDetail> UpdateAsync(LessonVideoDetail lessonVideoDetail);
    Task<LessonVideoDetail> DeleteAsync(LessonVideoDetail lessonVideoDetail, bool permanent = false);
}
