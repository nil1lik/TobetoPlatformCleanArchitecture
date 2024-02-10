using Application.Features.Calendars.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Calendars.Rules;

public class CalendarBusinessRules : BaseBusinessRules
{
    private readonly ICalendarRepository _calendarRepository;

    public CalendarBusinessRules(ICalendarRepository calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }

    public Task CalendarShouldExistWhenSelected(Calendar? calendar)
    {
        if (calendar == null)
            throw new BusinessException(CalendarsBusinessMessages.CalendarNotExists);
        return Task.CompletedTask;
    }

    public async Task CalendarIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Calendar? calendar = await _calendarRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CalendarShouldExistWhenSelected(calendar);
    }
}