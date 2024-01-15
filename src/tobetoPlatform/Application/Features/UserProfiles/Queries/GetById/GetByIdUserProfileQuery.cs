using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserProfiles.Queries.GetById;

public class GetByIdUserProfileQuery : IRequest<GetByIdUserProfileResponse>
{
    public int Id { get; set; }

    public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, GetByIdUserProfileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetByIdUserProfileQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetByIdUserProfileResponse> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: up => up.Id == request.Id, 
                include:up=>up.Include(up => up.User),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetByIdUserProfileResponse response = _mapper.Map<GetByIdUserProfileResponse>(userProfile);
            return response;
        }
    }
}