using Application.Features.ApplicationForms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ApplicationForms.Rules;

public class ApplicationFormBusinessRules : BaseBusinessRules
{
    private readonly IApplicationFormRepository _applicationFormRepository;

    public ApplicationFormBusinessRules(IApplicationFormRepository applicationFormRepository)
    {
        _applicationFormRepository = applicationFormRepository;
    }

    public Task ApplicationFormShouldExistWhenSelected(ApplicationForm? applicationForm)
    {
        if (applicationForm == null)
            throw new BusinessException(ApplicationFormsBusinessMessages.ApplicationFormNotExists);
        return Task.CompletedTask;
    }

    public async Task ApplicationFormIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ApplicationForm? applicationForm = await _applicationFormRepository.GetAsync(
            predicate: af => af.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationFormShouldExistWhenSelected(applicationForm);
    }
}