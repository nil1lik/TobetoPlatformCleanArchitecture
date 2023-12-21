using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserProfiles;

public interface IUserProfilesService
{
    Task<UserProfile?> GetAsync(
        Expression<Func<UserProfile, bool>> predicate,
        Func<IQueryable<UserProfile>, IIncludableQueryable<UserProfile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserProfile>?> GetListAsync(
        Expression<Func<UserProfile, bool>>? predicate = null,
        Func<IQueryable<UserProfile>, IOrderedQueryable<UserProfile>>? orderBy = null,
        Func<IQueryable<UserProfile>, IIncludableQueryable<UserProfile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserProfile> AddAsync(UserProfile userProfile);
    Task<UserProfile> UpdateAsync(UserProfile userProfile);
    Task<UserProfile> DeleteAsync(UserProfile userProfile, bool permanent = false);
}
