using Application.Features.CourseClasses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseClasses.Rules;

public class CourseClassBusinessRules : BaseBusinessRules
{
    private readonly ICourseClassRepository _courseClassRepository;

    public CourseClassBusinessRules(ICourseClassRepository courseClassRepository)
    {
        _courseClassRepository = courseClassRepository;
    }

    public Task CourseClassShouldExistWhenSelected(CourseClass? courseClass)
    {
        if (courseClass == null)
            throw new BusinessException(CourseClassesBusinessMessages.CourseClassNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseClassIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CourseClass? courseClass = await _courseClassRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseClassShouldExistWhenSelected(courseClass);
    }
}