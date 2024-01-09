using Application.Features.Calendars.Constants;
using Application.Features.Calendars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Calendars.Commands.Delete;

public class DeleteCalendarCommand : IRequest<DeletedCalendarResponse>
{
    public int Id { get; set; }

    public class DeleteCalendarCommandHandler : IRequestHandler<DeleteCalendarCommand, DeletedCalendarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;
        private readonly CalendarBusinessRules _calendarBusinessRules;

        public DeleteCalendarCommandHandler(IMapper mapper, ICalendarRepository calendarRepository,
                                         CalendarBusinessRules calendarBusinessRules)
        {
            _mapper = mapper;
            _calendarRepository = calendarRepository;
            _calendarBusinessRules = calendarBusinessRules;
        }

        public async Task<DeletedCalendarResponse> Handle(DeleteCalendarCommand request, CancellationToken cancellationToken)
        {
            Calendar? calendar = await _calendarRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _calendarBusinessRules.CalendarShouldExistWhenSelected(calendar);

            await _calendarRepository.DeleteAsync(calendar!);

            DeletedCalendarResponse response = _mapper.Map<DeletedCalendarResponse>(calendar);
            return response;
        }
    }
}