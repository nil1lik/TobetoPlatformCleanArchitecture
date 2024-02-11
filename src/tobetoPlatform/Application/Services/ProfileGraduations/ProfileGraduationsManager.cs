using Application.Features.ProfileGraduations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileGraduations;

public class ProfileGraduationsManager : IProfileGraduationsService
{
    private readonly IProfileGraduationRepository _profileGraduationRepository;
    private readonly ProfileGraduationBusinessRules _profileGraduationBusinessRules;

    public ProfileGraduationsManager(IProfileGraduationRepository profileGraduationRepository, ProfileGraduationBusinessRules profileGraduationBusinessRules)
    {
        _profileGraduationRepository = profileGraduationRepository;
        _profileGraduationBusinessRules = profileGraduationBusinessRules;
    }

    public async Task<ProfileGraduation?> GetAsync(
        Expression<Func<ProfileGraduation, bool>> predicate,
        Func<IQueryable<ProfileGraduation>, IIncludableQueryable<ProfileGraduation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileGraduation? profileGraduation = await _profileGraduationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileGraduation;
    }

    public async Task<IPaginate<ProfileGraduation>?> GetListAsync(
        Expression<Func<ProfileGraduation, bool>>? predicate = null,
        Func<IQueryable<ProfileGraduation>, IOrderedQueryable<ProfileGraduation>>? orderBy = null,
        Func<IQueryable<ProfileGraduation>, IIncludableQueryable<ProfileGraduation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileGraduation> profileGraduationList = await _profileGraduationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileGraduationList;
    }

    public async Task<ProfileGraduation> AddAsync(ProfileGraduation profileGraduation)
    {
        ProfileGraduation addedProfileGraduation = await _profileGraduationRepository.AddAsync(profileGraduation);

        return addedProfileGraduation;
    }

    public async Task<ProfileGraduation> UpdateAsync(ProfileGraduation profileGraduation)
    {
        ProfileGraduation updatedProfileGraduation = await _profileGraduationRepository.UpdateAsync(profileGraduation);

        return updatedProfileGraduation;
    }

    public async Task<ProfileGraduation> DeleteAsync(ProfileGraduation profileGraduation, bool permanent = false)
    {
        ProfileGraduation deletedProfileGraduation = await _profileGraduationRepository.DeleteAsync(profileGraduation);

        return deletedProfileGraduation;
    }
}
