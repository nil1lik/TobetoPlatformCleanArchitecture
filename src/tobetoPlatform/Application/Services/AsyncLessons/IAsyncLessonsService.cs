using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AsyncLessons;

public interface IAsyncLessonsService
{
    Task<AsyncLesson?> GetAsync(
        Expression<Func<AsyncLesson, bool>> predicate,
        Func<IQueryable<AsyncLesson>, IIncludableQueryable<AsyncLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AsyncLesson>?> GetListAsync(
        Expression<Func<AsyncLesson, bool>>? predicate = null,
        Func<IQueryable<AsyncLesson>, IOrderedQueryable<AsyncLesson>>? orderBy = null,
        Func<IQueryable<AsyncLesson>, IIncludableQueryable<AsyncLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AsyncLesson> AddAsync(AsyncLesson asyncLesson);
    Task<AsyncLesson> UpdateAsync(AsyncLesson asyncLesson);
    Task<AsyncLesson> DeleteAsync(AsyncLesson asyncLesson, bool permanent = false);
}
