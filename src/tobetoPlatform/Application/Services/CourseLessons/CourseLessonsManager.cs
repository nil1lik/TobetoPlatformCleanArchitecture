using Application.Features.CourseLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseLessons;

public class CourseLessonsManager : ICourseLessonsService
{
    private readonly ICourseLessonRepository _courseLessonRepository;
    private readonly CourseLessonBusinessRules _courseLessonBusinessRules;

    public CourseLessonsManager(ICourseLessonRepository courseLessonRepository, CourseLessonBusinessRules courseLessonBusinessRules)
    {
        _courseLessonRepository = courseLessonRepository;
        _courseLessonBusinessRules = courseLessonBusinessRules;
    }

    public async Task<CourseLesson?> GetAsync(
        Expression<Func<CourseLesson, bool>> predicate,
        Func<IQueryable<CourseLesson>, IIncludableQueryable<CourseLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseLesson? courseLesson = await _courseLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseLesson;
    }

    public async Task<IPaginate<CourseLesson>?> GetListAsync(
        Expression<Func<CourseLesson, bool>>? predicate = null,
        Func<IQueryable<CourseLesson>, IOrderedQueryable<CourseLesson>>? orderBy = null,
        Func<IQueryable<CourseLesson>, IIncludableQueryable<CourseLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseLesson> courseLessonList = await _courseLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseLessonList;
    }

    public async Task<CourseLesson> AddAsync(CourseLesson courseLesson)
    {
        CourseLesson addedCourseLesson = await _courseLessonRepository.AddAsync(courseLesson);

        return addedCourseLesson;
    }

    public async Task<CourseLesson> UpdateAsync(CourseLesson courseLesson)
    {
        CourseLesson updatedCourseLesson = await _courseLessonRepository.UpdateAsync(courseLesson);

        return updatedCourseLesson;
    }

    public async Task<CourseLesson> DeleteAsync(CourseLesson courseLesson, bool permanent = false)
    {
        CourseLesson deletedCourseLesson = await _courseLessonRepository.DeleteAsync(courseLesson);

        return deletedCourseLesson;
    }
}
