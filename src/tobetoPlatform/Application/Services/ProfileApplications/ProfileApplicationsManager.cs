using Application.Features.ProfileApplications.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileApplications;

public class ProfileApplicationsManager : IProfileApplicationsService
{
    private readonly IProfileApplicationRepository _profileApplicationRepository;
    private readonly ProfileApplicationBusinessRules _profileApplicationBusinessRules;

    public ProfileApplicationsManager(IProfileApplicationRepository profileApplicationRepository, ProfileApplicationBusinessRules profileApplicationBusinessRules)
    {
        _profileApplicationRepository = profileApplicationRepository;
        _profileApplicationBusinessRules = profileApplicationBusinessRules;
    }

    public async Task<ProfileApplication?> GetAsync(
        Expression<Func<ProfileApplication, bool>> predicate,
        Func<IQueryable<ProfileApplication>, IIncludableQueryable<ProfileApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileApplication? profileApplication = await _profileApplicationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileApplication;
    }

    public async Task<IPaginate<ProfileApplication>?> GetListAsync(
        Expression<Func<ProfileApplication, bool>>? predicate = null,
        Func<IQueryable<ProfileApplication>, IOrderedQueryable<ProfileApplication>>? orderBy = null,
        Func<IQueryable<ProfileApplication>, IIncludableQueryable<ProfileApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileApplication> profileApplicationList = await _profileApplicationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileApplicationList;
    }

    public async Task<ProfileApplication> AddAsync(ProfileApplication profileApplication)
    {
        ProfileApplication addedProfileApplication = await _profileApplicationRepository.AddAsync(profileApplication);

        return addedProfileApplication;
    }

    public async Task<ProfileApplication> UpdateAsync(ProfileApplication profileApplication)
    {
        ProfileApplication updatedProfileApplication = await _profileApplicationRepository.UpdateAsync(profileApplication);

        return updatedProfileApplication;
    }

    public async Task<ProfileApplication> DeleteAsync(ProfileApplication profileApplication, bool permanent = false)
    {
        ProfileApplication deletedProfileApplication = await _profileApplicationRepository.DeleteAsync(profileApplication);

        return deletedProfileApplication;
    }
}
