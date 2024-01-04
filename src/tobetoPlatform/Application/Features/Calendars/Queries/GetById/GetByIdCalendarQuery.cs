using Application.Features.Calendars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Calendars.Queries.GetById;

public class GetByIdCalendarQuery : IRequest<GetByIdCalendarResponse>
{
    public int Id { get; set; }

    public class GetByIdCalendarQueryHandler : IRequestHandler<GetByIdCalendarQuery, GetByIdCalendarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;
        private readonly CalendarBusinessRules _calendarBusinessRules;

        public GetByIdCalendarQueryHandler(IMapper mapper, ICalendarRepository calendarRepository, CalendarBusinessRules calendarBusinessRules)
        {
            _mapper = mapper;
            _calendarRepository = calendarRepository;
            _calendarBusinessRules = calendarBusinessRules;
        }

        public async Task<GetByIdCalendarResponse> Handle(GetByIdCalendarQuery request, CancellationToken cancellationToken)
        {
            Calendar? calendar = await _calendarRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _calendarBusinessRules.CalendarShouldExistWhenSelected(calendar);

            GetByIdCalendarResponse response = _mapper.Map<GetByIdCalendarResponse>(calendar);
            return response;
        }
    }
}