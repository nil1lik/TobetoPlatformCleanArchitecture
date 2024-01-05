using Application.Features.ApplicationSteps.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationSteps;

public class ApplicationStepsManager : IApplicationStepsService
{
    private readonly IApplicationStepRepository _applicationStepRepository;
    private readonly ApplicationStepBusinessRules _applicationStepBusinessRules;

    public ApplicationStepsManager(IApplicationStepRepository applicationStepRepository, ApplicationStepBusinessRules applicationStepBusinessRules)
    {
        _applicationStepRepository = applicationStepRepository;
        _applicationStepBusinessRules = applicationStepBusinessRules;
    }

    public async Task<ApplicationStep?> GetAsync(
        Expression<Func<ApplicationStep, bool>> predicate,
        Func<IQueryable<ApplicationStep>, IIncludableQueryable<ApplicationStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationStep? applicationStep = await _applicationStepRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return applicationStep;
    }

    public async Task<IPaginate<ApplicationStep>?> GetListAsync(
        Expression<Func<ApplicationStep, bool>>? predicate = null,
        Func<IQueryable<ApplicationStep>, IOrderedQueryable<ApplicationStep>>? orderBy = null,
        Func<IQueryable<ApplicationStep>, IIncludableQueryable<ApplicationStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationStep> applicationStepList = await _applicationStepRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationStepList;
    }

    public async Task<ApplicationStep> AddAsync(ApplicationStep applicationStep)
    {
        ApplicationStep addedApplicationStep = await _applicationStepRepository.AddAsync(applicationStep);

        return addedApplicationStep;
    }

    public async Task<ApplicationStep> UpdateAsync(ApplicationStep applicationStep)
    {
        ApplicationStep updatedApplicationStep = await _applicationStepRepository.UpdateAsync(applicationStep);

        return updatedApplicationStep;
    }

    public async Task<ApplicationStep> DeleteAsync(ApplicationStep applicationStep, bool permanent = false)
    {
        ApplicationStep deletedApplicationStep = await _applicationStepRepository.DeleteAsync(applicationStep);

        return deletedApplicationStep;
    }
}
