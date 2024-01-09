using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyRepository : IAsyncRepository<Company, int>, IRepository<Company, int>
{
}