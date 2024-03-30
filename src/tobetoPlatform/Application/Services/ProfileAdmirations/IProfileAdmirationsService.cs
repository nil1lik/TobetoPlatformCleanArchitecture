using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileAdmirations;

public interface IProfileAdmirationsService
{
    Task<ProfileAdmiration?> GetAsync(
        Expression<Func<ProfileAdmiration, bool>> predicate,
        Func<IQueryable<ProfileAdmiration>, IIncludableQueryable<ProfileAdmiration, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileAdmiration>?> GetListAsync(
        Expression<Func<ProfileAdmiration, bool>>? predicate = null,
        Func<IQueryable<ProfileAdmiration>, IOrderedQueryable<ProfileAdmiration>>? orderBy = null,
        Func<IQueryable<ProfileAdmiration>, IIncludableQueryable<ProfileAdmiration, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileAdmiration> AddAsync(ProfileAdmiration profileAdmiration);
    Task<ProfileAdmiration> UpdateAsync(ProfileAdmiration profileAdmiration);
    Task<ProfileAdmiration> DeleteAsync(ProfileAdmiration profileAdmiration, bool permanent = false);
}
