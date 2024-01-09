using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileApplicationSteps;

public interface IProfileApplicationStepsService
{
    Task<ProfileApplicationStep?> GetAsync(
        Expression<Func<ProfileApplicationStep, bool>> predicate,
        Func<IQueryable<ProfileApplicationStep>, IIncludableQueryable<ProfileApplicationStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileApplicationStep>?> GetListAsync(
        Expression<Func<ProfileApplicationStep, bool>>? predicate = null,
        Func<IQueryable<ProfileApplicationStep>, IOrderedQueryable<ProfileApplicationStep>>? orderBy = null,
        Func<IQueryable<ProfileApplicationStep>, IIncludableQueryable<ProfileApplicationStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileApplicationStep> AddAsync(ProfileApplicationStep profileApplicationStep);
    Task<ProfileApplicationStep> UpdateAsync(ProfileApplicationStep profileApplicationStep);
    Task<ProfileApplicationStep> DeleteAsync(ProfileApplicationStep profileApplicationStep, bool permanent = false);
}
