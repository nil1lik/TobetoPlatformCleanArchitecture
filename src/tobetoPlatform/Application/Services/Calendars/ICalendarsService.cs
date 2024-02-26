using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Calendars;

public interface ICalendarsService
{
    Task<Calendar?> GetAsync(
        Expression<Func<Calendar, bool>> predicate,
        Func<IQueryable<Calendar>, IIncludableQueryable<Calendar, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Calendar>?> GetListAsync(
        Expression<Func<Calendar, bool>>? predicate = null,
        Func<IQueryable<Calendar>, IOrderedQueryable<Calendar>>? orderBy = null,
        Func<IQueryable<Calendar>, IIncludableQueryable<Calendar, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Calendar> AddAsync(Calendar calendar);
    Task<Calendar> UpdateAsync(Calendar calendar);
    Task<Calendar> DeleteAsync(Calendar calendar, bool permanent = false);
}
