using Core.Application.Responses;

namespace Application.Features.Calendars.Commands.Delete;

public class DeletedCalendarResponse : IResponse
{
    public int Id { get; set; }
}