using Application.Features.ProfileClasses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileClasses.Rules;

public class ProfileClassBusinessRules : BaseBusinessRules
{
    private readonly IProfileClassRepository _profileClassRepository;

    public ProfileClassBusinessRules(IProfileClassRepository profileClassRepository)
    {
        _profileClassRepository = profileClassRepository;
    }

    public Task ProfileClassShouldExistWhenSelected(ProfileClass? profileClass)
    {
        if (profileClass == null)
            throw new BusinessException(ProfileClassesBusinessMessages.ProfileClassNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileClassIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileClass? profileClass = await _profileClassRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileClassShouldExistWhenSelected(profileClass);
    }
}