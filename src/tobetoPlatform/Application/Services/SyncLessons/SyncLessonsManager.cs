using Application.Features.SyncLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SyncLessons;

public class SyncLessonsManager : ISyncLessonsService
{
    private readonly ISyncLessonRepository _syncLessonRepository;
    private readonly SyncLessonBusinessRules _syncLessonBusinessRules;

    public SyncLessonsManager(ISyncLessonRepository syncLessonRepository, SyncLessonBusinessRules syncLessonBusinessRules)
    {
        _syncLessonRepository = syncLessonRepository;
        _syncLessonBusinessRules = syncLessonBusinessRules;
    }

    public async Task<SyncLesson?> GetAsync(
        Expression<Func<SyncLesson, bool>> predicate,
        Func<IQueryable<SyncLesson>, IIncludableQueryable<SyncLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return syncLesson;
    }

    public async Task<IPaginate<SyncLesson>?> GetListAsync(
        Expression<Func<SyncLesson, bool>>? predicate = null,
        Func<IQueryable<SyncLesson>, IOrderedQueryable<SyncLesson>>? orderBy = null,
        Func<IQueryable<SyncLesson>, IIncludableQueryable<SyncLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SyncLesson> syncLessonList = await _syncLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return syncLessonList;
    }

    public async Task<SyncLesson> AddAsync(SyncLesson syncLesson)
    {
        SyncLesson addedSyncLesson = await _syncLessonRepository.AddAsync(syncLesson);

        return addedSyncLesson;
    }

    public async Task<SyncLesson> UpdateAsync(SyncLesson syncLesson)
    {
        SyncLesson updatedSyncLesson = await _syncLessonRepository.UpdateAsync(syncLesson);

        return updatedSyncLesson;
    }

    public async Task<SyncLesson> DeleteAsync(SyncLesson syncLesson, bool permanent = false)
    {
        SyncLesson deletedSyncLesson = await _syncLessonRepository.DeleteAsync(syncLesson);

        return deletedSyncLesson;
    }
}
