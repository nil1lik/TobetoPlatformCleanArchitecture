using Application.Features.ProfileSkills.Queries.GetById;
using Application.Features.ProfileSkills.Queries.GetList;
using Application.Features.ProfileSkills.Rules;
using Application.Features.Skills.Rules;
using Application.Features.UserProfiles.Rules;
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

namespace Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
public class GetAllSkillByUserIdQuery : IRequest<GetListSkillByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllSkillByUserIdQueryHandler : IRequestHandler<GetAllSkillByUserIdQuery, GetListSkillByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetAllSkillByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetListSkillByUserIdResponse> Handle(GetAllSkillByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.ProfileSkills).ThenInclude(x => x.Skill),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetListSkillByUserIdResponse response = _mapper.Map<GetListSkillByUserIdResponse>(userProfile);
            return response;
        }
    }
}
