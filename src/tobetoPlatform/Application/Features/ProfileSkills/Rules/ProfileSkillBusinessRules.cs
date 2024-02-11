using Application.Features.ProfileSkills.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileSkills.Rules;

public class ProfileSkillBusinessRules : BaseBusinessRules
{
    private readonly IProfileSkillRepository _profileSkillRepository;

    public ProfileSkillBusinessRules(IProfileSkillRepository profileSkillRepository)
    {
        _profileSkillRepository = profileSkillRepository;
    }

    public Task ProfileSkillShouldExistWhenSelected(ProfileSkill? profileSkill)
    {
        if (profileSkill == null)
            throw new BusinessException(ProfileSkillsBusinessMessages.ProfileSkillNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileSkillIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(
            predicate: ps => ps.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileSkillShouldExistWhenSelected(profileSkill);
    }
}