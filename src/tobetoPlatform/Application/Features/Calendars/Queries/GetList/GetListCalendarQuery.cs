using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Calendars.Queries.GetList;

public class GetListCalendarQuery : IRequest<GetListResponse<GetListCalendarListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCalendarQueryHandler : IRequestHandler<GetListCalendarQuery, GetListResponse<GetListCalendarListItemDto>>
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;

        public GetListCalendarQueryHandler(ICalendarRepository calendarRepository, IMapper mapper)
        {
            _calendarRepository = calendarRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCalendarListItemDto>> Handle(GetListCalendarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Calendar> calendars = await _calendarRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCalendarListItemDto> response = _mapper.Map<GetListResponse<GetListCalendarListItemDto>>(calendars);
            return response;
        }
    }
}