using Application.Features.UserProfiles.Queries.GetUserProfileInformations;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetUserDetail;
public class GetUserProfileInformationsQuery : IRequest<GetUserProfileInformationsDto>
{
    public int Id { get; set; }

    public class GetUserProfileInformationsQueryHandler : IRequestHandler<GetUserProfileInformationsQuery, GetUserProfileInformationsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetUserProfileInformationsQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetUserProfileInformationsDto> Handle(GetUserProfileInformationsQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: up => up.Id == request.Id,
                include: up => up.Include(up => up.User)
                                 .Include(up => up.ProfileExams)
                                 .Include(up => up.ProfileSkills)
                                 .Include(up => up.ProfileLanguages).ThenInclude(l=> l.LanguageLevel)
                                 .Include(up => up.Certificates)
                                 .Include(up => up.Experiences)
                                 .Include(up => up.Graduations)
                                 .Include(up => up.SocialMediaAccounts).ThenInclude(s=> s.SocialMediaCategory),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetUserProfileInformationsDto response = _mapper.Map<GetUserProfileInformationsDto>(userProfile);
            return response;
        }
    }
}