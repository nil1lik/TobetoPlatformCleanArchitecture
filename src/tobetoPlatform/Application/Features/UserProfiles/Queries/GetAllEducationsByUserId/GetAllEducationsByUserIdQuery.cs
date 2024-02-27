using Amazon.Runtime.Internal;
using Application.Features.UserProfiles.Queries.GetExperienceByUserId;
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

namespace Application.Features.UserProfiles.Queries.GetAllEducationsByUserId;
public class GetAllEducationsByUserIdQuery:IRequest<GetAllEducationsByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllEducationsByUserIdQueryHandler : IRequestHandler<GetAllEducationsByUserIdQuery, GetAllEducationsByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetAllEducationsByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetAllEducationsByUserIdResponse> Handle(GetAllEducationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x=> x.ProfileEducations).ThenInclude(x=>x.EducationPath),
                cancellationToken: cancellationToken);

            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetAllEducationsByUserIdResponse response = _mapper.Map<GetAllEducationsByUserIdResponse>(userProfile);
            return response;
        }
    }
}
