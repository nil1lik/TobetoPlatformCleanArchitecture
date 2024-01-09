using Application.Features.SyncLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SyncLessons.Rules;

public class SyncLessonBusinessRules : BaseBusinessRules
{
    private readonly ISyncLessonRepository _syncLessonRepository;

    public SyncLessonBusinessRules(ISyncLessonRepository syncLessonRepository)
    {
        _syncLessonRepository = syncLessonRepository;
    }

    public Task SyncLessonShouldExistWhenSelected(SyncLesson? syncLesson)
    {
        if (syncLesson == null)
            throw new BusinessException(SyncLessonsBusinessMessages.SyncLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task SyncLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(
            predicate: sl => sl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SyncLessonShouldExistWhenSelected(syncLesson);
    }
}