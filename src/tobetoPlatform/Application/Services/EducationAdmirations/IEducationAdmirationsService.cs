using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationAdmirations;

public interface IEducationAdmirationsService
{
    Task<EducationAdmiration?> GetAsync(
        Expression<Func<EducationAdmiration, bool>> predicate,
        Func<IQueryable<EducationAdmiration>, IIncludableQueryable<EducationAdmiration, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EducationAdmiration>?> GetListAsync(
        Expression<Func<EducationAdmiration, bool>>? predicate = null,
        Func<IQueryable<EducationAdmiration>, IOrderedQueryable<EducationAdmiration>>? orderBy = null,
        Func<IQueryable<EducationAdmiration>, IIncludableQueryable<EducationAdmiration, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EducationAdmiration> AddAsync(EducationAdmiration educationAdmiration);
    Task<EducationAdmiration> UpdateAsync(EducationAdmiration educationAdmiration);
    Task<EducationAdmiration> DeleteAsync(EducationAdmiration educationAdmiration, bool permanent = false);
}
