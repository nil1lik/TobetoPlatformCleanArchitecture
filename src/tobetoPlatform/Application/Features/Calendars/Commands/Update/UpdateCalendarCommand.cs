using Application.Features.Calendars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Calendars.Commands.Update;

public class UpdateCalendarCommand : IRequest<UpdatedCalendarResponse>
{
    public int Id { get; set; }
    public int SyncLessonId { get; set; }
    public int InstructorId { get; set; }
    public int EducationPathId { get; set; }

    public class UpdateCalendarCommandHandler : IRequestHandler<UpdateCalendarCommand, UpdatedCalendarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;
        private readonly CalendarBusinessRules _calendarBusinessRules;

        public UpdateCalendarCommandHandler(IMapper mapper, ICalendarRepository calendarRepository,
                                         CalendarBusinessRules calendarBusinessRules)
        {
            _mapper = mapper;
            _calendarRepository = calendarRepository;
            _calendarBusinessRules = calendarBusinessRules;
        }

        public async Task<UpdatedCalendarResponse> Handle(UpdateCalendarCommand request, CancellationToken cancellationToken)
        {
            Calendar? calendar = await _calendarRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _calendarBusinessRules.CalendarShouldExistWhenSelected(calendar);
            calendar = _mapper.Map(request, calendar);

            await _calendarRepository.UpdateAsync(calendar!);

            UpdatedCalendarResponse response = _mapper.Map<UpdatedCalendarResponse>(calendar);
            return response;
        }
    }
}