using Application.Features.CourseClasses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseClasses;

public class CourseClassesManager : ICourseClassesService
{
    private readonly ICourseClassRepository _courseClassRepository;
    private readonly CourseClassBusinessRules _courseClassBusinessRules;

    public CourseClassesManager(ICourseClassRepository courseClassRepository, CourseClassBusinessRules courseClassBusinessRules)
    {
        _courseClassRepository = courseClassRepository;
        _courseClassBusinessRules = courseClassBusinessRules;
    }

    public async Task<CourseClass?> GetAsync(
        Expression<Func<CourseClass, bool>> predicate,
        Func<IQueryable<CourseClass>, IIncludableQueryable<CourseClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseClass? courseClass = await _courseClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseClass;
    }

    public async Task<IPaginate<CourseClass>?> GetListAsync(
        Expression<Func<CourseClass, bool>>? predicate = null,
        Func<IQueryable<CourseClass>, IOrderedQueryable<CourseClass>>? orderBy = null,
        Func<IQueryable<CourseClass>, IIncludableQueryable<CourseClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseClass> courseClassList = await _courseClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseClassList;
    }

    public async Task<CourseClass> AddAsync(CourseClass courseClass)
    {
        CourseClass addedCourseClass = await _courseClassRepository.AddAsync(courseClass);

        return addedCourseClass;
    }

    public async Task<CourseClass> UpdateAsync(CourseClass courseClass)
    {
        CourseClass updatedCourseClass = await _courseClassRepository.UpdateAsync(courseClass);

        return updatedCourseClass;
    }

    public async Task<CourseClass> DeleteAsync(CourseClass courseClass, bool permanent = false)
    {
        CourseClass deletedCourseClass = await _courseClassRepository.DeleteAsync(courseClass);

        return deletedCourseClass;
    }
}
