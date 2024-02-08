﻿using Amazon.Runtime.Internal;
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

namespace Application.Features.Calendar.Queries.GetList;
public class GetListCalenderQuery : IRequest<GetListResponse<GetListCalenderListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public int userId;

    public class GetListProgileAddressQueryHandler : IRequestHandler<GetListCalenderQuery, GetListResponse<GetListCalenderListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseInstructorRepository _courseInstructorRepository;

        public GetListProgileAddressQueryHandler(IMapper mapper, ICourseInstructorRepository courseInstructorRepository)
        {
            _mapper = mapper;
            _courseInstructorRepository = courseInstructorRepository;
        }

        public async Task<GetListResponse<GetListCalenderListItemDto>> Handle(GetListCalenderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseInstructor> syncLessons = await _courseInstructorRepository.GetListAsync(
                include: p => p.Include(x => x.Instructor).Include(x=>x.Course).ThenInclude(x=>x.SyncLessons),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<GetListCalenderListItemDto> response = _mapper.Map<GetListResponse<GetListCalenderListItemDto>>(syncLessons);
            return response;
        }
    }
}
