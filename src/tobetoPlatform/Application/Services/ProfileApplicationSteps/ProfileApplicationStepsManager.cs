using Application.Features.ProfileApplicationSteps.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileApplicationSteps;

public class ProfileApplicationStepsManager : IProfileApplicationStepsService
{
    private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;
    private readonly ProfileApplicationStepBusinessRules _profileApplicationStepBusinessRules;

    public ProfileApplicationStepsManager(IProfileApplicationStepRepository profileApplicationStepRepository, ProfileApplicationStepBusinessRules profileApplicationStepBusinessRules)
    {
        _profileApplicationStepRepository = profileApplicationStepRepository;
        _profileApplicationStepBusinessRules = profileApplicationStepBusinessRules;
    }

    public async Task<ProfileApplicationStep?> GetAsync(
        Expression<Func<ProfileApplicationStep, bool>> predicate,
        Func<IQueryable<ProfileApplicationStep>, IIncludableQueryable<ProfileApplicationStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileApplicationStep? profileApplicationStep = await _profileApplicationStepRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileApplicationStep;
    }

    public async Task<IPaginate<ProfileApplicationStep>?> GetListAsync(
        Expression<Func<ProfileApplicationStep, bool>>? predicate = null,
        Func<IQueryable<ProfileApplicationStep>, IOrderedQueryable<ProfileApplicationStep>>? orderBy = null,
        Func<IQueryable<ProfileApplicationStep>, IIncludableQueryable<ProfileApplicationStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileApplicationStep> profileApplicationStepList = await _profileApplicationStepRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileApplicationStepList;
    }

    public async Task<ProfileApplicationStep> AddAsync(ProfileApplicationStep profileApplicationStep)
    {
        ProfileApplicationStep addedProfileApplicationStep = await _profileApplicationStepRepository.AddAsync(profileApplicationStep);

        return addedProfileApplicationStep;
    }

    public async Task<ProfileApplicationStep> UpdateAsync(ProfileApplicationStep profileApplicationStep)
    {
        ProfileApplicationStep updatedProfileApplicationStep = await _profileApplicationStepRepository.UpdateAsync(profileApplicationStep);

        return updatedProfileApplicationStep;
    }

    public async Task<ProfileApplicationStep> DeleteAsync(ProfileApplicationStep profileApplicationStep, bool permanent = false)
    {
        ProfileApplicationStep deletedProfileApplicationStep = await _profileApplicationStepRepository.DeleteAsync(profileApplicationStep);

        return deletedProfileApplicationStep;
    }
}
