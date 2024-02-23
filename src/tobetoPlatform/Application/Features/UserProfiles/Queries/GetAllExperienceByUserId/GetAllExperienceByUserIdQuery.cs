
using Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
using Application.Features.UserProfiles.Queries.GetExperienceByUserId;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserProfiles.Queries.GetAllExperienceByUserId;
public class GetAllExperienceByUserIdQuery : IRequest<GetListExperienceByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllSkillByUserIdQueryHandler : IRequestHandler<GetAllExperienceByUserIdQuery, GetListExperienceByUserIdResponse>
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

        public async Task<GetListExperienceByUserIdResponse> Handle(GetAllExperienceByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.Experiences).ThenInclude(x => x.City),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetListExperienceByUserIdResponse response = _mapper.Map<GetListExperienceByUserIdResponse>(userProfile);
            return response;
        }
    }
}