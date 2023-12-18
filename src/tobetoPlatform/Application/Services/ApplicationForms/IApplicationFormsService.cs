using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationForms;

public interface IApplicationFormsService
{
    Task<ApplicationForm?> GetAsync(
        Expression<Func<ApplicationForm, bool>> predicate,
        Func<IQueryable<ApplicationForm>, IIncludableQueryable<ApplicationForm, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationForm>?> GetListAsync(
        Expression<Func<ApplicationForm, bool>>? predicate = null,
        Func<IQueryable<ApplicationForm>, IOrderedQueryable<ApplicationForm>>? orderBy = null,
        Func<IQueryable<ApplicationForm>, IIncludableQueryable<ApplicationForm, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationForm> AddAsync(ApplicationForm applicationForm);
    Task<ApplicationForm> UpdateAsync(ApplicationForm applicationForm);
    Task<ApplicationForm> DeleteAsync(ApplicationForm applicationForm, bool permanent = false);
}
