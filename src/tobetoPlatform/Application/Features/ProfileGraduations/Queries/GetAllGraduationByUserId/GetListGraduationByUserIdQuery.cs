using Application.Features.ProfileGraduations.Queries.GetList;
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

namespace Application.Features.ProfileGraduations.Queries.GetAllGraduationByUserId;
public class GetListGraduationByUserIdQuery : IRequest<GetListResponse<GetListGraduationItemResponse>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGraduationByUserIdQueryHandler : IRequestHandler<GetListGraduationByUserIdQuery, GetListResponse<GetListGraduationItemResponse>>
    {
        private readonly IProfileGraduationRepository _profileGraduationRepository;
        private readonly IMapper _mapper;

        public GetListGraduationByUserIdQueryHandler(IProfileGraduationRepository profileGraduationRepository, IMapper mapper)
        {
            _profileGraduationRepository = profileGraduationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGraduationItemResponse>> Handle(GetListGraduationByUserIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileGraduation> profileGraduations = await _profileGraduationRepository.GetListAsync(
                include: x=>x.Include(x=>x.Graduation),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGraduationItemResponse> response = _mapper.Map<GetListResponse<GetListGraduationItemResponse>>(profileGraduations);
            return response;
        }
    }
}
