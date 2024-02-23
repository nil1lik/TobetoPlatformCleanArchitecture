
using Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserProfiles.Queries.GetAllGraduationByUserId;
public class GetAllGraduationByUserIdQuery : IRequest<GetListGraduationByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllSkillByUserIdQueryHandler : IRequestHandler<GetAllGraduationByUserIdQuery, GetListGraduationByUserIdResponse>
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

        public async Task<GetListGraduationByUserIdResponse> Handle(GetAllGraduationByUserIdQuery request,CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.Graduations),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetListGraduationByUserIdResponse response = _mapper.Map<GetListGraduationByUserIdResponse>(userProfile);
            return response;
        }
    }
}
