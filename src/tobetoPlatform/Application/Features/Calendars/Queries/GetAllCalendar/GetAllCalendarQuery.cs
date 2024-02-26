using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendars.Queries.GetAllCalendar;
public class GetAllCalenderQuery : IRequest<GetListResponse<GetAllCalenderListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetAllCalenderQueryHandler : IRequestHandler<GetAllCalenderQuery, GetListResponse<GetAllCalenderListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _calendarRepository;

        public GetAllCalenderQueryHandler(IMapper mapper, ICalendarRepository calendarRepository)
        {
            _mapper = mapper;
            _calendarRepository = calendarRepository;
        }

        public async Task<GetListResponse<GetAllCalenderListItemDto>> Handle(GetAllCalenderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Calendar> calendar = await _calendarRepository.GetListAsync(
                include: p => p.Include(x=>x.SyncLesson)
                .Include(x=>x.Instructor).
                Include(x=>x.EducationPath),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetAllCalenderListItemDto> response = _mapper.Map<GetListResponse<GetAllCalenderListItemDto>>(calendar);
            return response;
        }

    }
}
