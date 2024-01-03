using Application.Features.UserProfiles.Constants;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Commands.Delete;

public class DeleteUserProfileCommand : IRequest<DeletedUserProfileResponse>
{
    public int Id { get; set; }

    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public DeleteUserProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository,
                                         UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<DeletedUserProfileResponse> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            await _userProfileRepository.DeleteAsync(userProfile!);

            DeletedUserProfileResponse response = _mapper.Map<DeletedUserProfileResponse>(userProfile);
            return response;
        }
    }
}