using Application.Features.ProfileApplications.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileApplications.Rules;

public class ProfileApplicationBusinessRules : BaseBusinessRules
{
    private readonly IProfileApplicationRepository _profileApplicationRepository;

    public ProfileApplicationBusinessRules(IProfileApplicationRepository profileApplicationRepository)
    {
        _profileApplicationRepository = profileApplicationRepository;
    }

    public Task ProfileApplicationShouldExistWhenSelected(ProfileApplication? profileApplication)
    {
        if (profileApplication == null)
            throw new BusinessException(ProfileApplicationsBusinessMessages.ProfileApplicationNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileApplicationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileApplication? profileApplication = await _profileApplicationRepository.GetAsync(
            predicate: pa => pa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileApplicationShouldExistWhenSelected(profileApplication);
    }

    public async Task ProfileApplicationApplicationResult(bool isComplete, CancellationToken cancellationToken)
    {
        ProfileApplication? profileApplication = await _profileApplicationRepository.GetAsync(
            predicate: pa => pa.ProfileApplicationStep.IsCompleted == isComplete,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (profileApplication.ProfileApplicationStep.IsCompleted == true)
        {
            throw new BusinessException(ProfileApplicationsValidationMessages.ProfileApplicationResultApproved);
        }
        else if(profileApplication.ProfileApplicationStep.IsCompleted == false)
        {
            throw new BusinessException(ProfileApplicationsValidationMessages.ProfileApplicationResultReject);
        }

        await ProfileApplicationShouldExistWhenSelected(profileApplication);
    }
}