using Application.Features.CourseInstructors.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseInstructors;

public class CourseInstructorsManager : ICourseInstructorsService
{
    private readonly ICourseInstructorRepository _courseInstructorRepository;
    private readonly CourseInstructorBusinessRules _courseInstructorBusinessRules;

    public CourseInstructorsManager(ICourseInstructorRepository courseInstructorRepository, CourseInstructorBusinessRules courseInstructorBusinessRules)
    {
        _courseInstructorRepository = courseInstructorRepository;
        _courseInstructorBusinessRules = courseInstructorBusinessRules;
    }

    public async Task<CourseInstructor?> GetAsync(
        Expression<Func<CourseInstructor, bool>> predicate,
        Func<IQueryable<CourseInstructor>, IIncludableQueryable<CourseInstructor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseInstructor? courseInstructor = await _courseInstructorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseInstructor;
    }

    public async Task<IPaginate<CourseInstructor>?> GetListAsync(
        Expression<Func<CourseInstructor, bool>>? predicate = null,
        Func<IQueryable<CourseInstructor>, IOrderedQueryable<CourseInstructor>>? orderBy = null,
        Func<IQueryable<CourseInstructor>, IIncludableQueryable<CourseInstructor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseInstructor> courseInstructorList = await _courseInstructorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseInstructorList;
    }

    public async Task<CourseInstructor> AddAsync(CourseInstructor courseInstructor)
    {
        CourseInstructor addedCourseInstructor = await _courseInstructorRepository.AddAsync(courseInstructor);

        return addedCourseInstructor;
    }

    public async Task<CourseInstructor> UpdateAsync(CourseInstructor courseInstructor)
    {
        CourseInstructor updatedCourseInstructor = await _courseInstructorRepository.UpdateAsync(courseInstructor);

        return updatedCourseInstructor;
    }

    public async Task<CourseInstructor> DeleteAsync(CourseInstructor courseInstructor, bool permanent = false)
    {
        CourseInstructor deletedCourseInstructor = await _courseInstructorRepository.DeleteAsync(courseInstructor);

        return deletedCourseInstructor;
    }
}
