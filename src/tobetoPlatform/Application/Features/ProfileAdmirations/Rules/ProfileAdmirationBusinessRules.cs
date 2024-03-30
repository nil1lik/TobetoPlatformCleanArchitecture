using Application.Features.ProfileAdmirations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileAdmirations.Rules;

public class ProfileAdmirationBusinessRules : BaseBusinessRules
{
    private readonly IProfileAdmirationRepository _profileAdmirationRepository;

    public ProfileAdmirationBusinessRules(IProfileAdmirationRepository profileAdmirationRepository)
    {
        _profileAdmirationRepository = profileAdmirationRepository;
    }

    public Task ProfileAdmirationShouldExistWhenSelected(ProfileAdmiration? profileAdmiration)
    {
        if (profileAdmiration == null)
            throw new BusinessException(ProfileAdmirationsBusinessMessages.ProfileAdmirationNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileAdmirationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileAdmiration? profileAdmiration = await _profileAdmirationRepository.GetAsync(
            predicate: pa => pa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileAdmirationShouldExistWhenSelected(profileAdmiration);
    }
}