using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Graduations;

public interface IGraduationsService
{
    Task<Graduation?> GetAsync(
        Expression<Func<Graduation, bool>> predicate,
        Func<IQueryable<Graduation>, IIncludableQueryable<Graduation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Graduation>?> GetListAsync(
        Expression<Func<Graduation, bool>>? predicate = null,
        Func<IQueryable<Graduation>, IOrderedQueryable<Graduation>>? orderBy = null,
        Func<IQueryable<Graduation>, IIncludableQueryable<Graduation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Graduation> AddAsync(Graduation graduation);
    Task<Graduation> UpdateAsync(Graduation graduation);
    Task<Graduation> DeleteAsync(Graduation graduation, bool permanent = false);
}
