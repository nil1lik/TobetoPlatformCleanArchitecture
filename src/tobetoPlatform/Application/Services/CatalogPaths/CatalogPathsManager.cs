using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogPaths;

public class CatalogPathsManager : ICatalogPathsService
{
    private readonly ICatalogPathRepository _catalogPathRepository;
    private readonly CatalogPathBusinessRules _catalogPathBusinessRules;

    public CatalogPathsManager(ICatalogPathRepository catalogPathRepository, CatalogPathBusinessRules catalogPathBusinessRules)
    {
        _catalogPathRepository = catalogPathRepository;
        _catalogPathBusinessRules = catalogPathBusinessRules;
    }

    public async Task<CatalogPath?> GetAsync(
        Expression<Func<CatalogPath, bool>> predicate,
        Func<IQueryable<CatalogPath>, IIncludableQueryable<CatalogPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CatalogPath? catalogPath = await _catalogPathRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return catalogPath;
    }

    public async Task<IPaginate<CatalogPath>?> GetListAsync(
        Expression<Func<CatalogPath, bool>>? predicate = null,
        Func<IQueryable<CatalogPath>, IOrderedQueryable<CatalogPath>>? orderBy = null,
        Func<IQueryable<CatalogPath>, IIncludableQueryable<CatalogPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CatalogPath> catalogPathList = await _catalogPathRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return catalogPathList;
    }

    public async Task<CatalogPath> AddAsync(CatalogPath catalogPath)
    {
        CatalogPath addedCatalogPath = await _catalogPathRepository.AddAsync(catalogPath);

        return addedCatalogPath;
    }

    public async Task<CatalogPath> UpdateAsync(CatalogPath catalogPath)
    {
        CatalogPath updatedCatalogPath = await _catalogPathRepository.UpdateAsync(catalogPath);

        return updatedCatalogPath;
    }

    public async Task<CatalogPath> DeleteAsync(CatalogPath catalogPath, bool permanent = false)
    {
        CatalogPath deletedCatalogPath = await _catalogPathRepository.DeleteAsync(catalogPath);

        return deletedCatalogPath;
    }
}
