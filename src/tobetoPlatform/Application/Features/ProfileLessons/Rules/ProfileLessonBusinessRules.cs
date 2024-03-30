using Application.Features.ProfileLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileLessons.Rules;

public class ProfileLessonBusinessRules : BaseBusinessRules
{
    private readonly IProfileLessonRepository _profileLessonRepository;

    public ProfileLessonBusinessRules(IProfileLessonRepository profileLessonRepository)
    {
        _profileLessonRepository = profileLessonRepository;
    }

    public Task ProfileLessonShouldExistWhenSelected(ProfileLesson? profileLesson)
    {
        if (profileLesson == null)
            throw new BusinessException(ProfileLessonsBusinessMessages.ProfileLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileLesson? profileLesson = await _profileLessonRepository.GetAsync(
            predicate: pl => pl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileLessonShouldExistWhenSelected(profileLesson);
    }
}