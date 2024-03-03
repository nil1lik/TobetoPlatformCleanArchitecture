using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICatalogPathRepository : IAsyncRepository<CatalogPath, int>, IRepository<CatalogPath, int>
{
}