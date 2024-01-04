using Application.Features.ApplicationSteps.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ApplicationSteps.Rules;

public class ApplicationStepBusinessRules : BaseBusinessRules
{
    private readonly IApplicationStepRepository _applicationStepRepository;

    public ApplicationStepBusinessRules(IApplicationStepRepository applicationStepRepository)
    {
        _applicationStepRepository = applicationStepRepository;
    }

    public Task ApplicationStepShouldExistWhenSelected(ApplicationStep? applicationStep)
    {
        if (applicationStep == null)
            throw new BusinessException(ApplicationStepsBusinessMessages.ApplicationStepNotExists);
        return Task.CompletedTask;
    }

    public async Task ApplicationStepIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ApplicationStep? applicationStep = await _applicationStepRepository.GetAsync(
            predicate: as => as.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationStepShouldExistWhenSelected(applicationStep);
    }
}