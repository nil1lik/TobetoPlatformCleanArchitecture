using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileGraduations;

public interface IProfileGraduationsService
{
    Task<ProfileGraduation?> GetAsync(
        Expression<Func<ProfileGraduation, bool>> predicate,
        Func<IQueryable<ProfileGraduation>, IIncludableQueryable<ProfileGraduation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileGraduation>?> GetListAsync(
        Expression<Func<ProfileGraduation, bool>>? predicate = null,
        Func<IQueryable<ProfileGraduation>, IOrderedQueryable<ProfileGraduation>>? orderBy = null,
        Func<IQueryable<ProfileGraduation>, IIncludableQueryable<ProfileGraduation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileGraduation> AddAsync(ProfileGraduation profileGraduation);
    Task<ProfileGraduation> UpdateAsync(ProfileGraduation profileGraduation);
    Task<ProfileGraduation> DeleteAsync(ProfileGraduation profileGraduation, bool permanent = false);
}
