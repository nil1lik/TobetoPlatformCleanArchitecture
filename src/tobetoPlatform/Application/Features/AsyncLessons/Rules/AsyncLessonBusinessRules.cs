using Application.Features.AsyncLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AsyncLessons.Rules;

public class AsyncLessonBusinessRules : BaseBusinessRules
{
    private readonly IAsyncLessonRepository _asyncLessonRepository;

    public AsyncLessonBusinessRules(IAsyncLessonRepository asyncLessonRepository)
    {
        _asyncLessonRepository = asyncLessonRepository;
    }

    public Task AsyncLessonShouldExistWhenSelected(AsyncLesson? asyncLesson)
    {
        if (asyncLesson == null)
            throw new BusinessException(AsyncLessonsBusinessMessages.AsyncLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task AsyncLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AsyncLesson? asyncLesson = await _asyncLessonRepository.GetAsync(
            predicate: al => al.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AsyncLessonShouldExistWhenSelected(asyncLesson);
    }
}