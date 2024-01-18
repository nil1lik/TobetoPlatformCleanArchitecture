using Application.Features.UserApplications.Queries.GetList;
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

namespace Application.Features.UserApplications.Queries.GetApplicationDetailList;

public class GetListApplicationDetailQuery : IRequest<GetListResponse<GetListApplicationDetailListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListApplicationDetailQueryHandler : IRequestHandler<GetListApplicationDetailQuery, GetListResponse<GetListApplicationDetailListItemDto>>
    {
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly IMapper _mapper;

        public GetListApplicationDetailQueryHandler(IUserApplicationRepository userApplicationRepository, IMapper mapper)
        {
            _userApplicationRepository = userApplicationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationDetailListItemDto>> Handle(GetListApplicationDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserApplication> userApplications = await _userApplicationRepository.GetListAsync(
                include: p => p.Include(p => p.ApplicationSteps),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationDetailListItemDto> response = _mapper.Map<GetListResponse<GetListApplicationDetailListItemDto>>(userApplications);
            return response;
        }
    }
}

