using Application.Features.ProfileSkills.Queries.GetById;
using Application.Features.ProfileSkills.Queries.GetList;
using Application.Features.ProfileSkills.Rules;
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
public class GetAllSkillByUserIdQuery : IRequest<GetListSkillByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllSkillByUserIdQueryHandler : IRequestHandler<GetAllSkillByUserIdQuery, GetListSkillByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

        public GetAllSkillByUserIdQueryHandler(IMapper mapper, IProfileSkillRepository profileSkillRepository, ProfileSkillBusinessRules profileSkillBusinessRules)
        {
            _mapper = mapper;
            _profileSkillRepository = profileSkillRepository;
            _profileSkillBusinessRules = profileSkillBusinessRules;
        }

        public async Task<GetListSkillByUserIdResponse> Handle(GetAllSkillByUserIdQuery request, CancellationToken cancellationToken)
        {
            ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(
                predicate: ps => ps.UserProfileId == request.Id, 
                include: ps=>ps.Include(x=>x.Skill),
                cancellationToken: cancellationToken);
            await _profileSkillBusinessRules.ProfileSkillShouldExistWhenSelected(profileSkill);

            GetListSkillByUserIdResponse response = _mapper.Map<GetListSkillByUserIdResponse>(profileSkill);
            return response;
        }
    }
}
