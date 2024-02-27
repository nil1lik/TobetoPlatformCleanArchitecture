using Application.Features.ProfileEducations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileEducations.Rules;

public class ProfileEducationBusinessRules : BaseBusinessRules
{
    private readonly IProfileEducationRepository _profileEducationRepository;

    public ProfileEducationBusinessRules(IProfileEducationRepository profileEducationRepository)
    {
        _profileEducationRepository = profileEducationRepository;
    }

    public Task ProfileEducationShouldExistWhenSelected(ProfileEducation? profileEducation)
    {
        if (profileEducation == null)
            throw new BusinessException(ProfileEducationsBusinessMessages.ProfileEducationNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileEducationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileEducation? profileEducation = await _profileEducationRepository.GetAsync(
            predicate: pe => pe.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileEducationShouldExistWhenSelected(profileEducation);
    }
}