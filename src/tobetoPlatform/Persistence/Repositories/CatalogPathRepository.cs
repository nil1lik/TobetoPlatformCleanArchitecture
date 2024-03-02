using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CatalogPathRepository : EfRepositoryBase<CatalogPath, int, BaseDbContext>, ICatalogPathRepository
{
    public CatalogPathRepository(BaseDbContext context) : base(context)
    {
    }
}