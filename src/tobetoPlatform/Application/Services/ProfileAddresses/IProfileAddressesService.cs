using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileAddresses;

public interface IProfileAddressesService
{
    Task<ProfileAddress?> GetAsync(
        Expression<Func<ProfileAddress, bool>> predicate,
        Func<IQueryable<ProfileAddress>, IIncludableQueryable<ProfileAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileAddress>?> GetListAsync(
        Expression<Func<ProfileAddress, bool>>? predicate = null,
        Func<IQueryable<ProfileAddress>, IOrderedQueryable<ProfileAddress>>? orderBy = null,
        Func<IQueryable<ProfileAddress>, IIncludableQueryable<ProfileAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileAddress> AddAsync(ProfileAddress profileAddress);
    Task<ProfileAddress> UpdateAsync(ProfileAddress profileAddress);
    Task<ProfileAddress> DeleteAsync(ProfileAddress profileAddress, bool permanent = false);
}
