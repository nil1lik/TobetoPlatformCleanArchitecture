using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserApplications;

public interface IUserApplicationsService
{
    Task<UserApplication?> GetAsync(
        Expression<Func<UserApplication, bool>> predicate,
        Func<IQueryable<UserApplication>, IIncludableQueryable<UserApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserApplication>?> GetListAsync(
        Expression<Func<UserApplication, bool>>? predicate = null,
        Func<IQueryable<UserApplication>, IOrderedQueryable<UserApplication>>? orderBy = null,
        Func<IQueryable<UserApplication>, IIncludableQueryable<UserApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserApplication> AddAsync(UserApplication userApplication);
    Task<UserApplication> UpdateAsync(UserApplication userApplication);
    Task<UserApplication> DeleteAsync(UserApplication userApplication, bool permanent = false);
}
