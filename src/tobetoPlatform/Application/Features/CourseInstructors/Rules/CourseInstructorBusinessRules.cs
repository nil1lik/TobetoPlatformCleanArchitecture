using Application.Features.CourseInstructors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseInstructors.Rules;

public class CourseInstructorBusinessRules : BaseBusinessRules
{
    private readonly ICourseInstructorRepository _courseInstructorRepository;

    public CourseInstructorBusinessRules(ICourseInstructorRepository courseInstructorRepository)
    {
        _courseInstructorRepository = courseInstructorRepository;
    }

    public Task CourseInstructorShouldExistWhenSelected(CourseInstructor? courseInstructor)
    {
        if (courseInstructor == null)
            throw new BusinessException(CourseInstructorsBusinessMessages.CourseInstructorNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseInstructorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CourseInstructor? courseInstructor = await _courseInstructorRepository.GetAsync(
            predicate: ci => ci.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseInstructorShouldExistWhenSelected(courseInstructor);
    }
}