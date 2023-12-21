using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Commands.Create;

public class CreateUserProfileCommand : IRequest<CreatedUserProfileResponse>
{
    public int UserId { get; set; }
    public int ProfileApplicationId { get; set; }
    public int ProfileAddressId { get; set; }
    public int ProfileClassId { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public int ProfileGraduationId { get; set; }
    public int ProfileLanguageId { get; set; }
    public int ProfileSkillId { get; set; }
    public int ProfileExperienceId { get; set; }
    public int ProfileExamId { get; set; }
    public int ProfileSurveyId { get; set; }
    public int ProfileEducationId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }

    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public CreateUserProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository,
                                         UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<CreatedUserProfileResponse> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile userProfile = _mapper.Map<UserProfile>(request);

            await _userProfileRepository.AddAsync(userProfile);

            CreatedUserProfileResponse response = _mapper.Map<CreatedUserProfileResponse>(userProfile);
            return response;
        }
    }
}