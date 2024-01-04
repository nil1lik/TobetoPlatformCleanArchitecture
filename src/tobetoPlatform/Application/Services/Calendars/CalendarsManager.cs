using Application.Features.Calendars.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Calendars;

public class CalendarsManager : ICalendarsService
{
    private readonly ICalendarRepository _calendarRepository;
    private readonly CalendarBusinessRules _calendarBusinessRules;

    public CalendarsManager(ICalendarRepository calendarRepository, CalendarBusinessRules calendarBusinessRules)
    {
        _calendarRepository = calendarRepository;
        _calendarBusinessRules = calendarBusinessRules;
    }

    public async Task<Calendar?> GetAsync(
        Expression<Func<Calendar, bool>> predicate,
        Func<IQueryable<Calendar>, IIncludableQueryable<Calendar, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Calendar? calendar = await _calendarRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return calendar;
    }

    public async Task<IPaginate<Calendar>?> GetListAsync(
        Expression<Func<Calendar, bool>>? predicate = null,
        Func<IQueryable<Calendar>, IOrderedQueryable<Calendar>>? orderBy = null,
        Func<IQueryable<Calendar>, IIncludableQueryable<Calendar, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Calendar> calendarList = await _calendarRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return calendarList;
    }

    public async Task<Calendar> AddAsync(Calendar calendar)
    {
        Calendar addedCalendar = await _calendarRepository.AddAsync(calendar);

        return addedCalendar;
    }

    public async Task<Calendar> UpdateAsync(Calendar calendar)
    {
        Calendar updatedCalendar = await _calendarRepository.UpdateAsync(calendar);

        return updatedCalendar;
    }

    public async Task<Calendar> DeleteAsync(Calendar calendar, bool permanent = false)
    {
        Calendar deletedCalendar = await _calendarRepository.DeleteAsync(calendar);

        return deletedCalendar;
    }
}
