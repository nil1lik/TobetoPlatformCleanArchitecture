using Application.Features.ProfileApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplications.Commands.Create;

public class CreateProfileApplicationCommand : IRequest<CreatedProfileApplicationResponse>
{
    public int ProfileId { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }

    public class CreateProfileApplicationCommandHandler : IRequestHandler<CreateProfileApplicationCommand, CreatedProfileApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationRepository _profileApplicationRepository;
        private readonly ProfileApplicationBusinessRules _profileApplicationBusinessRules;

        public CreateProfileApplicationCommandHandler(IMapper mapper, IProfileApplicationRepository profileApplicationRepository,
                                         ProfileApplicationBusinessRules profileApplicationBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationRepository = profileApplicationRepository;
            _profileApplicationBusinessRules = profileApplicationBusinessRules;
        }

        public async Task<CreatedProfileApplicationResponse> Handle(CreateProfileApplicationCommand request, CancellationToken cancellationToken)
        {
            ProfileApplication profileApplication = _mapper.Map<ProfileApplication>(request);

            await _profileApplicationRepository.AddAsync(profileApplication);

            CreatedProfileApplicationResponse response = _mapper.Map<CreatedProfileApplicationResponse>(profileApplication);
            return response;
        }
    }
}