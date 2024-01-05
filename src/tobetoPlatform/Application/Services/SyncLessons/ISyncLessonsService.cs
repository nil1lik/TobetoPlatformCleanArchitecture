using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SyncLessons;

public interface ISyncLessonsService
{
    Task<SyncLesson?> GetAsync(
        Expression<Func<SyncLesson, bool>> predicate,
        Func<IQueryable<SyncLesson>, IIncludableQueryable<SyncLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SyncLesson>?> GetListAsync(
        Expression<Func<SyncLesson, bool>>? predicate = null,
        Func<IQueryable<SyncLesson>, IOrderedQueryable<SyncLesson>>? orderBy = null,
        Func<IQueryable<SyncLesson>, IIncludableQueryable<SyncLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SyncLesson> AddAsync(SyncLesson syncLesson);
    Task<SyncLesson> UpdateAsync(SyncLesson syncLesson);
    Task<SyncLesson> DeleteAsync(SyncLesson syncLesson, bool permanent = false);
}
