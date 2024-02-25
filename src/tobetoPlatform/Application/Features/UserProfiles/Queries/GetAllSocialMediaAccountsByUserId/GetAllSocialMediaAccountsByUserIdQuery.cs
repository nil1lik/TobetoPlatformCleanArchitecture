using Application.Features.UserProfiles.Queries.GetAllSocialMediaAccountsByUserId;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserProfiles.Queries.GetAllGraduationByUserId;
public class GetAllSocialMediaAccountsByUserIdQuery : IRequest<GetListSocialMediaAccountsByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllSkillByUserIdQueryHandler : IRequestHandler<GetAllSocialMediaAccountsByUserIdQuery, GetListSocialMediaAccountsByUserIdResponse>
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

        public async Task<GetListSocialMediaAccountsByUserIdResponse> Handle(GetAllSocialMediaAccountsByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.SocialMediaAccounts).ThenInclude(x=>x.SocialMediaCategory),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetListSocialMediaAccountsByUserIdResponse response = _mapper.Map<GetListSocialMediaAccountsByUserIdResponse>(userProfile);
            return response;
        }
    }
}
