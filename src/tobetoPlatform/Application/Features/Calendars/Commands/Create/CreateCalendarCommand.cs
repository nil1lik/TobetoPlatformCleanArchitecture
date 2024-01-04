using Application.Features.Calendars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Calendars.Commands.Create;

public class CreateCalendarCommand : IRequest<CreatedCalendarResponse>
{
    public int SyncLessonId { get; set; }
    public int EducationPathId { get; set; }
    public int InstructorId { get; set; }

    public class CreateCalendarCommandHandler : IRequestHandler<CreateCalendarCommand, CreatedCalendarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;
        private readonly CalendarBusinessRules _calendarBusinessRules;

        public CreateCalendarCommandHandler(IMapper mapper, ICalendarRepository calendarRepository,
                                         CalendarBusinessRules calendarBusinessRules)
        {
            _mapper = mapper;
            _calendarRepository = calendarRepository;
            _calendarBusinessRules = calendarBusinessRules;
        }

        public async Task<CreatedCalendarResponse> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            Calendar calendar = _mapper.Map<Calendar>(request);

            await _calendarRepository.AddAsync(calendar);

            CreatedCalendarResponse response = _mapper.Map<CreatedCalendarResponse>(calendar);
            return response;
        }
    }
}