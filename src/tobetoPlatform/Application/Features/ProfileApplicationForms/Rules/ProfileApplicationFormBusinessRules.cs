using Application.Features.ProfileApplicationForms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileApplicationForms.Rules;

public class ProfileApplicationFormBusinessRules : BaseBusinessRules
{
    private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;

    public ProfileApplicationFormBusinessRules(IProfileApplicationFormRepository profileApplicationFormRepository)
    {
        _profileApplicationFormRepository = profileApplicationFormRepository;
    }

    public Task ProfileApplicationFormShouldExistWhenSelected(ProfileApplicationForm? profileApplicationForm)
    {
        if (profileApplicationForm == null)
            throw new BusinessException(ProfileApplicationFormsBusinessMessages.ProfileApplicationFormNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileApplicationFormIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileApplicationForm? profileApplicationForm = await _profileApplicationFormRepository.GetAsync(
            predicate: paf => paf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileApplicationFormShouldExistWhenSelected(profileApplicationForm);
    }
}