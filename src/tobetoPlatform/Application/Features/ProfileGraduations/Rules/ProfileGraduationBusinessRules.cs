using Application.Features.ProfileGraduations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileGraduations.Rules;

public class ProfileGraduationBusinessRules : BaseBusinessRules
{
    private readonly IProfileGraduationRepository _profileGraduationRepository;

    public ProfileGraduationBusinessRules(IProfileGraduationRepository profileGraduationRepository)
    {
        _profileGraduationRepository = profileGraduationRepository;
    }

    public Task ProfileGraduationShouldExistWhenSelected(ProfileGraduation? profileGraduation)
    {
        if (profileGraduation == null)
            throw new BusinessException(ProfileGraduationsBusinessMessages.ProfileGraduationNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileGraduationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileGraduation? profileGraduation = await _profileGraduationRepository.GetAsync(
            predicate: pg => pg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileGraduationShouldExistWhenSelected(profileGraduation);
    }
}