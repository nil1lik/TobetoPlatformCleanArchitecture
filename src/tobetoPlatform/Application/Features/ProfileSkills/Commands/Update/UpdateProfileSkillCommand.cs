using Application.Features.ProfileSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileSkills.Commands.Update;

public class UpdateProfileSkillCommand : IRequest<UpdatedProfileSkillResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }

    public class UpdateProfileSkillCommandHandler : IRequestHandler<UpdateProfileSkillCommand, UpdatedProfileSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

        public UpdateProfileSkillCommandHandler(IMapper mapper, IProfileSkillRepository profileSkillRepository,
                                         ProfileSkillBusinessRules profileSkillBusinessRules)
        {
            _mapper = mapper;
            _profileSkillRepository = profileSkillRepository;
            _profileSkillBusinessRules = profileSkillBusinessRules;
        }

        public async Task<UpdatedProfileSkillResponse> Handle(UpdateProfileSkillCommand request, CancellationToken cancellationToken)
        {
            ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _profileSkillBusinessRules.ProfileSkillShouldExistWhenSelected(profileSkill);
            profileSkill = _mapper.Map(request, profileSkill);

            await _profileSkillRepository.UpdateAsync(profileSkill!);

            UpdatedProfileSkillResponse response = _mapper.Map<UpdatedProfileSkillResponse>(profileSkill);
            return response;
        }
    }
}