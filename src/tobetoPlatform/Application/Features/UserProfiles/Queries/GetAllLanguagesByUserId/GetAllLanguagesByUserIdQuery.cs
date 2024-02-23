using Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Azure;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllLanguageByUserId;
public class GetAllLanguagesByUserIdQuery : IRequest<GetAllLanguagesByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllLanguageByUserIdQueryHandler : IRequestHandler<GetAllLanguagesByUserIdQuery, GetAllLanguagesByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetAllLanguageByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetAllLanguagesByUserIdResponse> Handle(GetAllLanguagesByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.ProfileLanguages)
                                 .ThenInclude(pl => pl.Language).Include(x=>x.ProfileLanguages).ThenInclude(x=>x.LanguageLevel),
                enableTracking: false,
                cancellationToken: cancellationToken
                );
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetAllLanguagesByUserIdResponse response = _mapper.Map<GetAllLanguagesByUserIdResponse>(userProfile);

            return response;
        }
    }
}
