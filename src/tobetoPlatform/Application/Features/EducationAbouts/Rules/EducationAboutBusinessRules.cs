using Application.Features.EducationAbouts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EducationAbouts.Rules;

public class EducationAboutBusinessRules : BaseBusinessRules
{
    private readonly IEducationAboutRepository _educationAboutRepository;

    public EducationAboutBusinessRules(IEducationAboutRepository educationAboutRepository)
    {
        _educationAboutRepository = educationAboutRepository;
    }

    public Task EducationAboutShouldExistWhenSelected(EducationAbout? educationAbout)
    {
        if (educationAbout == null)
            throw new BusinessException(EducationAboutsBusinessMessages.EducationAboutNotExists);
        return Task.CompletedTask;
    }

    public async Task EducationAboutIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(
            predicate: ea => ea.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EducationAboutShouldExistWhenSelected(educationAbout);
    }
}