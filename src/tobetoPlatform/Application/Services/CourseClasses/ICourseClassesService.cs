using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseClasses;

public interface ICourseClassesService
{
    Task<CourseClass?> GetAsync(
        Expression<Func<CourseClass, bool>> predicate,
        Func<IQueryable<CourseClass>, IIncludableQueryable<CourseClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseClass>?> GetListAsync(
        Expression<Func<CourseClass, bool>>? predicate = null,
        Func<IQueryable<CourseClass>, IOrderedQueryable<CourseClass>>? orderBy = null,
        Func<IQueryable<CourseClass>, IIncludableQueryable<CourseClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseClass> AddAsync(CourseClass courseClass);
    Task<CourseClass> UpdateAsync(CourseClass courseClass);
    Task<CourseClass> DeleteAsync(CourseClass courseClass, bool permanent = false);
}
