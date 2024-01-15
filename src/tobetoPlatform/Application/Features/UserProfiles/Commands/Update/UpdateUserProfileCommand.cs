using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Azure;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdateUserProfileCommand : IRequest<UpdatedUserProfileResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProfileAddressId { get; set; }
    public int ProfileShareId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }

    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public UpdateUserProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository,
                                         UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<UpdatedUserProfileResponse> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);
            userProfile = _mapper.Map(request, userProfile);

            await _userProfileRepository.UpdateAsync(userProfile!);
            
            UpdatedUserProfileResponse response = _mapper.Map<UpdatedUserProfileResponse>(userProfile);
            return response;
        }
    }
}