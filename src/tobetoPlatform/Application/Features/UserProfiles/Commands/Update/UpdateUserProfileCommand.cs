using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Azure;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdateUserProfileCommand : IRequest<UpdatedUserProfileResponse>
{
    public int? Id { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
    public string? Message { get; set; }

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
            response.Message = "Bilgileriniz ba�ar�yla g�ncellendi";
            return response;
        }
    }
}