using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileApplications;

public interface IProfileApplicationsService
{
    Task<ProfileApplication?> GetAsync(
        Expression<Func<ProfileApplication, bool>> predicate,
        Func<IQueryable<ProfileApplication>, IIncludableQueryable<ProfileApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileApplication>?> GetListAsync(
        Expression<Func<ProfileApplication, bool>>? predicate = null,
        Func<IQueryable<ProfileApplication>, IOrderedQueryable<ProfileApplication>>? orderBy = null,
        Func<IQueryable<ProfileApplication>, IIncludableQueryable<ProfileApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileApplication> AddAsync(ProfileApplication profileApplication);
    Task<ProfileApplication> UpdateAsync(ProfileApplication profileApplication);
    Task<ProfileApplication> DeleteAsync(ProfileApplication profileApplication, bool permanent = false);
}
