using Application.Features.ProfileEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileEducations.Commands.Create;

public class CreateProfileEducationCommand : IRequest<CreatedProfileEducationResponse>
{
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }

    public class CreateProfileEducationCommandHandler : IRequestHandler<CreateProfileEducationCommand, CreatedProfileEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEducationRepository _profileEducationRepository;
        private readonly ProfileEducationBusinessRules _profileEducationBusinessRules;

        public CreateProfileEducationCommandHandler(IMapper mapper, IProfileEducationRepository profileEducationRepository,
                                         ProfileEducationBusinessRules profileEducationBusinessRules)
        {
            _mapper = mapper;
            _profileEducationRepository = profileEducationRepository;
            _profileEducationBusinessRules = profileEducationBusinessRules;
        }

        public async Task<CreatedProfileEducationResponse> Handle(CreateProfileEducationCommand request, CancellationToken cancellationToken)
        {
            ProfileEducation profileEducation = _mapper.Map<ProfileEducation>(request);

            await _profileEducationRepository.AddAsync(profileEducation);

            CreatedProfileEducationResponse response = _mapper.Map<CreatedProfileEducationResponse>(profileEducation);
            return response;
        }
    }
}