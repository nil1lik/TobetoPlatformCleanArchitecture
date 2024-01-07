using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationPaths;

public interface IEducationPathsService
{
    Task<EducationPath?> GetAsync(
        Expression<Func<EducationPath, bool>> predicate,
        Func<IQueryable<EducationPath>, IIncludableQueryable<EducationPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EducationPath>?> GetListAsync(
        Expression<Func<EducationPath, bool>>? predicate = null,
        Func<IQueryable<EducationPath>, IOrderedQueryable<EducationPath>>? orderBy = null,
        Func<IQueryable<EducationPath>, IIncludableQueryable<EducationPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EducationPath> AddAsync(EducationPath educationPath);
    Task<EducationPath> UpdateAsync(EducationPath educationPath);
    Task<EducationPath> DeleteAsync(EducationPath educationPath, bool permanent = false);
}
