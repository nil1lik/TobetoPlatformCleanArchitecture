using Application.Features.ProfileEducations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileEducations;

public class ProfileEducationsManager : IProfileEducationsService
{
    private readonly IProfileEducationRepository _profileEducationRepository;
    private readonly ProfileEducationBusinessRules _profileEducationBusinessRules;

    public ProfileEducationsManager(IProfileEducationRepository profileEducationRepository, ProfileEducationBusinessRules profileEducationBusinessRules)
    {
        _profileEducationRepository = profileEducationRepository;
        _profileEducationBusinessRules = profileEducationBusinessRules;
    }

    public async Task<ProfileEducation?> GetAsync(
        Expression<Func<ProfileEducation, bool>> predicate,
        Func<IQueryable<ProfileEducation>, IIncludableQueryable<ProfileEducation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileEducation? profileEducation = await _profileEducationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileEducation;
    }

    public async Task<IPaginate<ProfileEducation>?> GetListAsync(
        Expression<Func<ProfileEducation, bool>>? predicate = null,
        Func<IQueryable<ProfileEducation>, IOrderedQueryable<ProfileEducation>>? orderBy = null,
        Func<IQueryable<ProfileEducation>, IIncludableQueryable<ProfileEducation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileEducation> profileEducationList = await _profileEducationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileEducationList;
    }

    public async Task<ProfileEducation> AddAsync(ProfileEducation profileEducation)
    {
        ProfileEducation addedProfileEducation = await _profileEducationRepository.AddAsync(profileEducation);

        return addedProfileEducation;
    }

    public async Task<ProfileEducation> UpdateAsync(ProfileEducation profileEducation)
    {
        ProfileEducation updatedProfileEducation = await _profileEducationRepository.UpdateAsync(profileEducation);

        return updatedProfileEducation;
    }

    public async Task<ProfileEducation> DeleteAsync(ProfileEducation profileEducation, bool permanent = false)
    {
        ProfileEducation deletedProfileEducation = await _profileEducationRepository.DeleteAsync(profileEducation);

        return deletedProfileEducation;
    }
}
