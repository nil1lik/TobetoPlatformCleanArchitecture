using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationSteps;

public interface IApplicationStepsService
{
    Task<ApplicationStep?> GetAsync(
        Expression<Func<ApplicationStep, bool>> predicate,
        Func<IQueryable<ApplicationStep>, IIncludableQueryable<ApplicationStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationStep>?> GetListAsync(
        Expression<Func<ApplicationStep, bool>>? predicate = null,
        Func<IQueryable<ApplicationStep>, IOrderedQueryable<ApplicationStep>>? orderBy = null,
        Func<IQueryable<ApplicationStep>, IIncludableQueryable<ApplicationStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationStep> AddAsync(ApplicationStep applicationStep);
    Task<ApplicationStep> UpdateAsync(ApplicationStep applicationStep);
    Task<ApplicationStep> DeleteAsync(ApplicationStep applicationStep, bool permanent = false);
}
