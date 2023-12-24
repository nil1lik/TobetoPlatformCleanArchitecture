using Application.Features.EducationAdmirations.Constants;
using Application.Services.Repositories;
using Core.Application.Dtos;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;

namespace Application.Features.EducationAdmirations.Rules;

public class EducationAdmirationBusinessRules : BaseBusinessRules
{
    private readonly IEducationAdmirationRepository _educationAdmirationRepository;
    private readonly IEducationAboutRepository _educationAboutRepository;

    public EducationAdmirationBusinessRules(IEducationAdmirationRepository educationAdmirationRepository, IEducationAboutRepository educationAboutRepository)
    {
        _educationAdmirationRepository = educationAdmirationRepository;
        _educationAboutRepository = educationAboutRepository;
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

    //EducationPath'de hi�bir video izlenmediyse...
    public async Task CheckUnwatchedVideosOnEducationPath(int userProfileId, CancellationToken cancellationToken)
    {
        EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(
            predicate: ea => ea.Id == userProfileId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(
            predicate: ea => ea.Id == userProfileId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (educationAdmiration.CompletionRate == 0)
        {
            throw new BusinessException(educationAbout.EndDate + EducationAdmirationsBusinessMessages.NoVideoWatched);
        }
    }

}