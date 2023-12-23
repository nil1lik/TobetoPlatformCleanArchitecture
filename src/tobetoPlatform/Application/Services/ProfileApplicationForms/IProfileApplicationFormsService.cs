using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileApplicationForms;

public interface IProfileApplicationFormsService
{
    Task<ProfileApplicationForm?> GetAsync(
        Expression<Func<ProfileApplicationForm, bool>> predicate,
        Func<IQueryable<ProfileApplicationForm>, IIncludableQueryable<ProfileApplicationForm, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileApplicationForm>?> GetListAsync(
        Expression<Func<ProfileApplicationForm, bool>>? predicate = null,
        Func<IQueryable<ProfileApplicationForm>, IOrderedQueryable<ProfileApplicationForm>>? orderBy = null,
        Func<IQueryable<ProfileApplicationForm>, IIncludableQueryable<ProfileApplicationForm, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileApplicationForm> AddAsync(ProfileApplicationForm profileApplicationForm);
    Task<ProfileApplicationForm> UpdateAsync(ProfileApplicationForm profileApplicationForm);
    Task<ProfileApplicationForm> DeleteAsync(ProfileApplicationForm profileApplicationForm, bool permanent = false);
}
