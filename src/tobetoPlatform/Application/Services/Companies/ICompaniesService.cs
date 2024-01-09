using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Companies;

public interface ICompaniesService
{
    Task<Company?> GetAsync(
        Expression<Func<Company, bool>> predicate,
        Func<IQueryable<Company>, IIncludableQueryable<Company, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Company>?> GetListAsync(
        Expression<Func<Company, bool>>? predicate = null,
        Func<IQueryable<Company>, IOrderedQueryable<Company>>? orderBy = null,
        Func<IQueryable<Company>, IIncludableQueryable<Company, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Company> AddAsync(Company company);
    Task<Company> UpdateAsync(Company company);
    Task<Company> DeleteAsync(Company company, bool permanent = false);
}
