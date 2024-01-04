using Application.Features.AsyncLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AsyncLessons;

public class AsyncLessonsManager : IAsyncLessonsService
{
    private readonly IAsyncLessonRepository _asyncLessonRepository;
    private readonly AsyncLessonBusinessRules _asyncLessonBusinessRules;

    public AsyncLessonsManager(IAsyncLessonRepository asyncLessonRepository, AsyncLessonBusinessRules asyncLessonBusinessRules)
    {
        _asyncLessonRepository = asyncLessonRepository;
        _asyncLessonBusinessRules = asyncLessonBusinessRules;
    }

    public async Task<AsyncLesson?> GetAsync(
        Expression<Func<AsyncLesson, bool>> predicate,
        Func<IQueryable<AsyncLesson>, IIncludableQueryable<AsyncLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AsyncLesson? asyncLesson = await _asyncLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return asyncLesson;
    }

    public async Task<IPaginate<AsyncLesson>?> GetListAsync(
        Expression<Func<AsyncLesson, bool>>? predicate = null,
        Func<IQueryable<AsyncLesson>, IOrderedQueryable<AsyncLesson>>? orderBy = null,
        Func<IQueryable<AsyncLesson>, IIncludableQueryable<AsyncLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AsyncLesson> asyncLessonList = await _asyncLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return asyncLessonList;
    }

    public async Task<AsyncLesson> AddAsync(AsyncLesson asyncLesson)
    {
        AsyncLesson addedAsyncLesson = await _asyncLessonRepository.AddAsync(asyncLesson);

        return addedAsyncLesson;
    }

    public async Task<AsyncLesson> UpdateAsync(AsyncLesson asyncLesson)
    {
        AsyncLesson updatedAsyncLesson = await _asyncLessonRepository.UpdateAsync(asyncLesson);

        return updatedAsyncLesson;
    }

    public async Task<AsyncLesson> DeleteAsync(AsyncLesson asyncLesson, bool permanent = false)
    {
        AsyncLesson deletedAsyncLesson = await _asyncLessonRepository.DeleteAsync(asyncLesson);

        return deletedAsyncLesson;
    }
}
