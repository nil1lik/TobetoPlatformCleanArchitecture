using Application.Features.ProfileAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileAdmirations.Commands.Create;

public class CreateProfileAdmirationCommand : IRequest<CreatedProfileAdmirationResponse>
{
    public int UserProfileId { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationPathId { get; set; }

    public class CreateProfileAdmirationCommandHandler : IRequestHandler<CreateProfileAdmirationCommand, CreatedProfileAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAdmirationRepository _profileAdmirationRepository;
        private readonly ProfileAdmirationBusinessRules _profileAdmirationBusinessRules;

        public CreateProfileAdmirationCommandHandler(IMapper mapper, IProfileAdmirationRepository profileAdmirationRepository,
                                         ProfileAdmirationBusinessRules profileAdmirationBusinessRules)
        {
            _mapper = mapper;
            _profileAdmirationRepository = profileAdmirationRepository;
            _profileAdmirationBusinessRules = profileAdmirationBusinessRules;
        }

        public async Task<CreatedProfileAdmirationResponse> Handle(CreateProfileAdmirationCommand request, CancellationToken cancellationToken)
        {
            ProfileAdmiration profileAdmiration = _mapper.Map<ProfileAdmiration>(request);

            await _profileAdmirationRepository.AddAsync(profileAdmiration);

            CreatedProfileAdmirationResponse response = _mapper.Map<CreatedProfileAdmirationResponse>(profileAdmiration);
            return response;
        }
    }
}