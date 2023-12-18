using Application.Features.CourseLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseLessons.Rules;

public class CourseLessonBusinessRules : BaseBusinessRules
{
    private readonly ICourseLessonRepository _courseLessonRepository;

    public CourseLessonBusinessRules(ICourseLessonRepository courseLessonRepository)
    {
        _courseLessonRepository = courseLessonRepository;
    }

    public Task CourseLessonShouldExistWhenSelected(CourseLesson? courseLesson)
    {
        if (courseLesson == null)
            throw new BusinessException(CourseLessonsBusinessMessages.CourseLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CourseLesson? courseLesson = await _courseLessonRepository.GetAsync(
            predicate: cl => cl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseLessonShouldExistWhenSelected(courseLesson);
    }
}