using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileEducations;

public interface IProfileEducationsService
{
    Task<ProfileEducation?> GetAsync(
        Expression<Func<ProfileEducation, bool>> predicate,
        Func<IQueryable<ProfileEducation>, IIncludableQueryable<ProfileEducation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileEducation>?> GetListAsync(
        Expression<Func<ProfileEducation, bool>>? predicate = null,
        Func<IQueryable<ProfileEducation>, IOrderedQueryable<ProfileEducation>>? orderBy = null,
        Func<IQueryable<ProfileEducation>, IIncludableQueryable<ProfileEducation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileEducation> AddAsync(ProfileEducation profileEducation);
    Task<ProfileEducation> UpdateAsync(ProfileEducation profileEducation);
    Task<ProfileEducation> DeleteAsync(ProfileEducation profileEducation, bool permanent = false);
}
