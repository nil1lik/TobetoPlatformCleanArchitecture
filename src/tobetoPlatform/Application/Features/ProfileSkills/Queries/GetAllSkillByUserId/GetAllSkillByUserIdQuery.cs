using Application.Features.ProfileSkills.Queries.GetList;
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

namespace Application.Features.ProfileSkills.Queries.GetAllSkillByUserId;
public class GetAllSkillByUserIdQuery : IRequest<GetListResponse<GetListSkillByUserIdResponse>>
{
    public PageRequest PageRequest { get; set; }

    public class GetAllSkillByUserIdQueryHandler : IRequestHandler<GetAllSkillByUserIdQuery, GetListResponse<GetListSkillByUserIdResponse>>
    {
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly IMapper _mapper;

        public GetAllSkillByUserIdQueryHandler(IProfileSkillRepository profileSkillRepository, IMapper mapper)
        {
            _profileSkillRepository = profileSkillRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSkillByUserIdResponse>> Handle(GetAllSkillByUserIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileSkill> profileSkills = await _profileSkillRepository.GetListAsync(
                include:x=>x.Include(x=>x.Skill),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSkillByUserIdResponse> response = _mapper.Map<GetListResponse<GetListSkillByUserIdResponse>>(profileSkills);
            return response;
        }
    }
}
