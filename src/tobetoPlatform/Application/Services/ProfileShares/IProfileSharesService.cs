using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileShares;

public interface IProfileSharesService
{
    Task<ProfileShare?> GetAsync(
        Expression<Func<ProfileShare, bool>> predicate,
        Func<IQueryable<ProfileShare>, IIncludableQueryable<ProfileShare, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileShare>?> GetListAsync(
        Expression<Func<ProfileShare, bool>>? predicate = null,
        Func<IQueryable<ProfileShare>, IOrderedQueryable<ProfileShare>>? orderBy = null,
        Func<IQueryable<ProfileShare>, IIncludableQueryable<ProfileShare, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileShare> AddAsync(ProfileShare profileShare);
    Task<ProfileShare> UpdateAsync(ProfileShare profileShare);
    Task<ProfileShare> DeleteAsync(ProfileShare profileShare, bool permanent = false);
}
