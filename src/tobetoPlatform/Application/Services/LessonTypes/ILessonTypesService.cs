using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonTypes;

public interface ILessonTypesService
{
    Task<LessonType?> GetAsync(
        Expression<Func<LessonType, bool>> predicate,
        Func<IQueryable<LessonType>, IIncludableQueryable<LessonType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonType>?> GetListAsync(
        Expression<Func<LessonType, bool>>? predicate = null,
        Func<IQueryable<LessonType>, IOrderedQueryable<LessonType>>? orderBy = null,
        Func<IQueryable<LessonType>, IIncludableQueryable<LessonType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonType> AddAsync(LessonType lessonType);
    Task<LessonType> UpdateAsync(LessonType lessonType);
    Task<LessonType> DeleteAsync(LessonType lessonType, bool permanent = false);
}
