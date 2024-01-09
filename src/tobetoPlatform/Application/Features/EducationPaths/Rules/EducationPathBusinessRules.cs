using Application.Features.EducationPaths.Constants;
using Application.Features.ProfileShares.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;

namespace Application.Features.EducationPaths.Rules;

public class EducationPathBusinessRules : BaseBusinessRules
{
    private readonly IEducationPathRepository _educationPathRepository;
    private readonly IEducationAdmirationRepository _educationAdmirationRepository;

    public EducationPathBusinessRules(IEducationPathRepository educationPathRepository, IEducationAdmirationRepository educationAdmirationRepository)
    {
        _educationPathRepository = educationPathRepository;
        _educationAdmirationRepository = educationAdmirationRepository;
    }

    public Task EducationPathShouldExistWhenSelected(EducationPath? educationPath)
    {
        if (educationPath == null)
            throw new BusinessException(EducationPathsBusinessMessages.EducationPathNotExists);
        return Task.CompletedTask;
    }

    public async Task EducationPathIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        EducationPath? educationPath = await _educationPathRepository.GetAsync(
            predicate: ep => ep.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EducationPathShouldExistWhenSelected(educationPath);
    }

    public async Task EducationPathVideoViewsStatus(double completionRate, CancellationToken cancellationToken)
    {
        EducationPath? educationPath = await _educationPathRepository.GetAsync(
            predicate: ep => ep.EducationAdmiration.CompletionRate == completionRate,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (educationPath.EducationAdmiration.CompletionRate == 0)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsBusinessMessages.VideoViewStatus);
        }

        else if (educationPath.EducationAdmiration.CompletionRate > 0)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsBusinessMessages.VideoViewStatus);
        }

        else if (educationPath.EducationAdmiration.CompletionRate == 100 && educationPath.EducationAdmiration.EducationPoint == 98.8)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsBusinessMessages.SuccessMessage);
        }

        else if (educationPath.EducationAdmiration.CompletionRate == 100 && educationPath.EducationAdmiration.EducationPoint == 100)
        {
            throw new BusinessException(educationPath.EducationAbout.EndDate + EducationPathsBusinessMessages.CompletionMessage);
        }
    }
}
