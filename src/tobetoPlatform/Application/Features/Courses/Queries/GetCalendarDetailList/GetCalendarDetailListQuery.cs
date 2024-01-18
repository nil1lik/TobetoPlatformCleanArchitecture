using Amazon.Runtime.Internal;
using Application.Features.Cities.Queries.GetDistrictList;
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

namespace Application.Features.Courses.Queries.GetCalendarDetailList;
public class GetCalendarDetailListQuery:IRequest<GetListResponse<GetCalendarDetailListDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetCalendarDetailListQueryHandler : IRequestHandler<GetCalendarDetailListQuery, GetListResponse<GetCalendarDetailListDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCalendarDetailListQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetCalendarDetailListDto>> Handle(GetCalendarDetailListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Course> courses = await _courseRepository.GetListAsync(
                include: p => p.Include(p => p.SyncLessons)
                               .Include(p => p.CourseInstructors),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetCalendarDetailListDto> response = _mapper.Map<GetListResponse<GetCalendarDetailListDto>>(courses);
            return response;
        }
    }
}
