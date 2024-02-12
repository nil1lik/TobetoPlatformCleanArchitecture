using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseLessons;

public interface ICourseLessonsService
{
    Task<CourseLesson?> GetAsync(
        Expression<Func<CourseLesson, bool>> predicate,
        Func<IQueryable<CourseLesson>, IIncludableQueryable<CourseLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseLesson>?> GetListAsync(
        Expression<Func<CourseLesson, bool>>? predicate = null,
        Func<IQueryable<CourseLesson>, IOrderedQueryable<CourseLesson>>? orderBy = null,
        Func<IQueryable<CourseLesson>, IIncludableQueryable<CourseLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseLesson> AddAsync(CourseLesson courseLesson);
    Task<CourseLesson> UpdateAsync(CourseLesson courseLesson);
    Task<CourseLesson> DeleteAsync(CourseLesson courseLesson, bool permanent = false);
}
