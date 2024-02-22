using Application.Features.UserProfiles.Queries.GetById;
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

namespace Application.Features.UserProfiles.Queries.GetByUserId;
public class GetByUserIdUserProfileQuery : IRequest<GetByUserIdUserProfileResponse>
{
    public int Id { get; set; }


    public class GetByUserIdUserProfileQueryHandler : IRequestHandler<GetByUserIdUserProfileQuery, GetByUserIdUserProfileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetByUserIdUserProfileQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetByUserIdUserProfileResponse> Handle(GetByUserIdUserProfileQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: up => up.Id == request.Id,
                include:x=>x.Include(x=>x.User),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetByUserIdUserProfileResponse response = _mapper.Map<GetByUserIdUserProfileResponse>(userProfile);
            return response;
        }
    }
}
