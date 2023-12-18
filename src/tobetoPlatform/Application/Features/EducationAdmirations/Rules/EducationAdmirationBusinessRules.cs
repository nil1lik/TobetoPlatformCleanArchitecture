using Application.Features.EducationAdmirations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EducationAdmirations.Rules;

public class EducationAdmirationBusinessRules : BaseBusinessRules
{
    private readonly IEducationAdmirationRepository _educationAdmirationRepository;

    public EducationAdmirationBusinessRules(IEducationAdmirationRepository educationAdmirationRepository)
    {
        _educationAdmirationRepository = educationAdmirationRepository;
    }

    public Task EducationAdmirationShouldExistWhenSelected(EducationAdmiration? educationAdmiration)
    {
        if (educationAdmiration == null)
            throw new BusinessException(EducationAdmirationsBusinessMessages.EducationAdmirationNotExists);
        return Task.CompletedTask;
    }

    public async Task EducationAdmirationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(
            predicate: ea => ea.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EducationAdmirationShouldExistWhenSelected(educationAdmiration);
    }
}