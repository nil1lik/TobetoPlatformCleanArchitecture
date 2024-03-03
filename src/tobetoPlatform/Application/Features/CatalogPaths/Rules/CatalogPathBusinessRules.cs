using Application.Features.CatalogPaths.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CatalogPaths.Rules;

public class CatalogPathBusinessRules : BaseBusinessRules
{
    private readonly ICatalogPathRepository _catalogPathRepository;

    public CatalogPathBusinessRules(ICatalogPathRepository catalogPathRepository)
    {
        _catalogPathRepository = catalogPathRepository;
    }

    public Task CatalogPathShouldExistWhenSelected(CatalogPath? catalogPath)
    {
        if (catalogPath == null)
            throw new BusinessException(CatalogPathsBusinessMessages.CatalogPathNotExists);
        return Task.CompletedTask;
    }

    public async Task CatalogPathIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CatalogPath? catalogPath = await _catalogPathRepository.GetAsync(
            predicate: cp => cp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CatalogPathShouldExistWhenSelected(catalogPath);
    }
}