using Application.Features.EducationPaths.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;

namespace Application.Features.EducationPaths.Rules;

public class EducationPathBusinessRules : BaseBusinessRules
{
    private readonly IEducationPathRepository _educationPathRepository;

    public EducationPathBusinessRules(IEducationPathRepository educationPathRepository)
    {
        _educationPathRepository = educationPathRepository;
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

}