using Application.Features.ProfileApplicationSteps.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileApplicationSteps.Rules;

public class ProfileApplicationStepBusinessRules : BaseBusinessRules
{
    private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;

    public ProfileApplicationStepBusinessRules(IProfileApplicationStepRepository profileApplicationStepRepository)
    {
        _profileApplicationStepRepository = profileApplicationStepRepository;
    }

    public Task ProfileApplicationStepShouldExistWhenSelected(ProfileApplicationStep? profileApplicationStep)
    {
        if (profileApplicationStep == null)
            throw new BusinessException(ProfileApplicationStepsBusinessMessages.ProfileApplicationStepNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileApplicationStepIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileApplicationStep? profileApplicationStep = await _profileApplicationStepRepository.GetAsync(
            predicate: pas => pas.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileApplicationStepShouldExistWhenSelected(profileApplicationStep);
    }
}