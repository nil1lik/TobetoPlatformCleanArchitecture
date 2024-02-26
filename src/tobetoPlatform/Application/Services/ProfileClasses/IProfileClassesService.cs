using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileClasses;

public interface IProfileClassesService
{
    Task<ProfileClass?> GetAsync(
        Expression<Func<ProfileClass, bool>> predicate,
        Func<IQueryable<ProfileClass>, IIncludableQueryable<ProfileClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileClass>?> GetListAsync(
        Expression<Func<ProfileClass, bool>>? predicate = null,
        Func<IQueryable<ProfileClass>, IOrderedQueryable<ProfileClass>>? orderBy = null,
        Func<IQueryable<ProfileClass>, IIncludableQueryable<ProfileClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileClass> AddAsync(ProfileClass profileClass);
    Task<ProfileClass> UpdateAsync(ProfileClass profileClass);
    Task<ProfileClass> DeleteAsync(ProfileClass profileClass, bool permanent = false);
}
