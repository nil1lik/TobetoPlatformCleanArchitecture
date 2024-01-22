using Application.Features.EducationAdmirations.Constants;
using Application.Features.EducationPaths.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EducationAdmirations.Rules;

public class EducationAdmirationBusinessRules : BaseBusinessRules
{
    private readonly IEducationAdmirationRepository _educationAdmirationRepository;
    private readonly IEducationPathRepository _educationPathRepository;

    public EducationAdmirationBusinessRules(IEducationAdmirationRepository educationAdmirationRepository, IEducationPathRepository educationPathRepository)
    {
        _educationAdmirationRepository = educationAdmirationRepository;
        _educationPathRepository = educationPathRepository;
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

    public async Task VideoViewsStatus(double completionRate, CancellationToken cancellationToken)
    {
        EducationPath? educationPath = await _educationPathRepository.GetAsync(
            predicate: ep => ep.EducationAdmiration.CompletionRate == completionRate,
            enableTracking: false,
            cancellationToken: cancellationToken
        ); 
         
        if (educationPath.EducationAdmiration.CompletionRate == EducationAdmirationsRuleTypes.VideoViewStatusPoint)
        { 
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsValidationMessages.VideoViewStatus);
        }

        else if (educationPath.EducationAdmiration.CompletionRate > EducationAdmirationsRuleTypes.VideoViewStatusPoint)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsValidationMessages.VideoViewStatus);
        } 

        else if (educationPath.EducationAdmiration.CompletionRate == EducationAdmirationsRuleTypes.CompletionRate && educationPath.EducationAdmiration.EducationPoint == EducationAdmirationsRuleTypes.SuccessPoint)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsValidationMessages.SuccessMessage); // + like?
        }

        else if (educationPath.EducationAdmiration.CompletionRate == EducationAdmirationsRuleTypes.CompletionRate && educationPath.EducationAdmiration.EducationPoint == EducationAdmirationsRuleTypes.CompletionPoint)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsValidationMessages.CompletionMessage); // + like?
        }
    }
} 