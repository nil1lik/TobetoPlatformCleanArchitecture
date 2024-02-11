using Application.Features.ProfileGraduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileGraduations.Commands.Create;

public class CreateProfileGraduationCommand : IRequest<CreatedProfileGraduationResponse>
{
    public int GraduationId { get; set; }
    public int UserProfileId { get; set; }

    public class CreateProfileGraduationCommandHandler : IRequestHandler<CreateProfileGraduationCommand, CreatedProfileGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileGraduationRepository _profileGraduationRepository;
        private readonly ProfileGraduationBusinessRules _profileGraduationBusinessRules;

        public CreateProfileGraduationCommandHandler(IMapper mapper, IProfileGraduationRepository profileGraduationRepository,
                                         ProfileGraduationBusinessRules profileGraduationBusinessRules)
        {
            _mapper = mapper;
            _profileGraduationRepository = profileGraduationRepository;
            _profileGraduationBusinessRules = profileGraduationBusinessRules;
        }

        public async Task<CreatedProfileGraduationResponse> Handle(CreateProfileGraduationCommand request, CancellationToken cancellationToken)
        {
            ProfileGraduation profileGraduation = _mapper.Map<ProfileGraduation>(request);

            await _profileGraduationRepository.AddAsync(profileGraduation);

            CreatedProfileGraduationResponse response = _mapper.Map<CreatedProfileGraduationResponse>(profileGraduation);
            return response;
        }
    }
}