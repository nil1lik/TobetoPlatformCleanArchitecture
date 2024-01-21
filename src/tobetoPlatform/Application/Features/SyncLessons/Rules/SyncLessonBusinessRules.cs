using Application.Features.SyncLessons.Constants;
using Application.Services.Repositories;
using Azure;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;
using System.Threading;

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

    public async Task SyncLessonEducationStatus(int syncLessonId, CancellationToken cancellationToken)
    {
        SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(
            predicate: sl => sl.Id == syncLessonId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SyncLessonShouldExistWhenSelected(syncLesson);

    }

    public async Task SyncLessonEducationStatus(DateTime dateTime, int syncLessonId, CancellationToken cancellationToken)
    {
        dateTime = DateTime.Now;
        SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(
            predicate: sl => sl.Id == syncLessonId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SyncLessonShouldExistWhenSelected(syncLesson);

        if (syncLesson.StartDate != dateTime)
        {
            throw new BusinessException(SyncLessonsBusinessMessages.SessionHasNotStartedYet);
        }

        else if (syncLesson.StartDate == dateTime)
        {
            throw new BusinessException(SyncLessonsBusinessMessages.NextSession);
        }

        else if (syncLesson.StartDate < dateTime && syncLesson.IsJoin == true)
        {
            throw new BusinessException(SyncLessonsBusinessMessages.SessionAttended + syncLesson.SyncVideoUrl);
        }

        else if (syncLesson.StartDate < dateTime && syncLesson.IsJoin == false)
        {
            throw new BusinessException(SyncLessonsBusinessMessages.SessionNotAttended + syncLesson.SyncVideoUrl);
        }
    }
}