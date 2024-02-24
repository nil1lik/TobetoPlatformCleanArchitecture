using Application.Features.ProfileSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileSkills.Commands.Create;

public class CreateProfileSkillCommand : IRequest<CreatedProfileSkillResponse>
{
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }

    public class CreateProfileSkillCommandHandler : IRequestHandler<CreateProfileSkillCommand, CreatedProfileSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

        public CreateProfileSkillCommandHandler(IMapper mapper, IProfileSkillRepository profileSkillRepository,
                                         ProfileSkillBusinessRules profileSkillBusinessRules)
        {
            _mapper = mapper;
            _profileSkillRepository = profileSkillRepository;
            _profileSkillBusinessRules = profileSkillBusinessRules;
        }

        public async Task<CreatedProfileSkillResponse> Handle(CreateProfileSkillCommand request, CancellationToken cancellationToken)
        {
            ProfileSkill profileSkill = _mapper.Map<ProfileSkill>(request);
            await _profileSkillBusinessRules.ProfileSkillCannotBeDuplicateWhenInserted(request.SkillId, cancellationToken);
            await _profileSkillRepository.AddAsync(profileSkill);

            CreatedProfileSkillResponse response = _mapper.Map<CreatedProfileSkillResponse>(profileSkill);
            return response;
        }
    }
}