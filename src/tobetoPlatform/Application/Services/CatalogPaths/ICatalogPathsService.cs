using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogPaths;

public interface ICatalogPathsService
{
    Task<CatalogPath?> GetAsync(
        Expression<Func<CatalogPath, bool>> predicate,
        Func<IQueryable<CatalogPath>, IIncludableQueryable<CatalogPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CatalogPath>?> GetListAsync(
        Expression<Func<CatalogPath, bool>>? predicate = null,
        Func<IQueryable<CatalogPath>, IOrderedQueryable<CatalogPath>>? orderBy = null,
        Func<IQueryable<CatalogPath>, IIncludableQueryable<CatalogPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CatalogPath> AddAsync(CatalogPath catalogPath);
    Task<CatalogPath> UpdateAsync(CatalogPath catalogPath);
    Task<CatalogPath> DeleteAsync(CatalogPath catalogPath, bool permanent = false);
}
