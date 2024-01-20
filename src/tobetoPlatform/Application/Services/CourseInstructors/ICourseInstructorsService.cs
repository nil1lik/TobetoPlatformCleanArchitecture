using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseInstructors;

public interface ICourseInstructorsService
{
    Task<CourseInstructor?> GetAsync(
        Expression<Func<CourseInstructor, bool>> predicate,
        Func<IQueryable<CourseInstructor>, IIncludableQueryable<CourseInstructor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseInstructor>?> GetListAsync(
        Expression<Func<CourseInstructor, bool>>? predicate = null,
        Func<IQueryable<CourseInstructor>, IOrderedQueryable<CourseInstructor>>? orderBy = null,
        Func<IQueryable<CourseInstructor>, IIncludableQueryable<CourseInstructor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseInstructor> AddAsync(CourseInstructor courseInstructor);
    Task<CourseInstructor> UpdateAsync(CourseInstructor courseInstructor);
    Task<CourseInstructor> DeleteAsync(CourseInstructor courseInstructor, bool permanent = false);
}
