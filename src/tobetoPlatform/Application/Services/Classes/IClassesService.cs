using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Classes;

public interface IClassesService
{
    Task<Class?> GetAsync(
        Expression<Func<Class, bool>> predicate,
        Func<IQueryable<Class>, IIncludableQueryable<Class, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Class>?> GetListAsync(
        Expression<Func<Class, bool>>? predicate = null,
        Func<IQueryable<Class>, IOrderedQueryable<Class>>? orderBy = null,
        Func<IQueryable<Class>, IIncludableQueryable<Class, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Class> AddAsync(Class class);
    Task<Class> UpdateAsync(Class class);
    Task<Class> DeleteAsync(Class class, bool permanent = false);
}
