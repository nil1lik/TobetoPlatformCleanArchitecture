using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationAbouts;

public interface IEducationAboutsService
{
    Task<EducationAbout?> GetAsync(
        Expression<Func<EducationAbout, bool>> predicate,
        Func<IQueryable<EducationAbout>, IIncludableQueryable<EducationAbout, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EducationAbout>?> GetListAsync(
        Expression<Func<EducationAbout, bool>>? predicate = null,
        Func<IQueryable<EducationAbout>, IOrderedQueryable<EducationAbout>>? orderBy = null,
        Func<IQueryable<EducationAbout>, IIncludableQueryable<EducationAbout, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EducationAbout> AddAsync(EducationAbout educationAbout);
    Task<EducationAbout> UpdateAsync(EducationAbout educationAbout);
    Task<EducationAbout> DeleteAsync(EducationAbout educationAbout, bool permanent = false);
}
