using Application.Features.ProfileLanguages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileLanguages;

public class ProfileLanguagesManager : IProfileLanguagesService
{
    private readonly IProfileLanguageRepository _profileLanguageRepository;
    private readonly ProfileLanguageBusinessRules _profileLanguageBusinessRules;

    public ProfileLanguagesManager(IProfileLanguageRepository profileLanguageRepository, ProfileLanguageBusinessRules profileLanguageBusinessRules)
    {
        _profileLanguageRepository = profileLanguageRepository;
        _profileLanguageBusinessRules = profileLanguageBusinessRules;
    }

    public async Task<ProfileLanguage?> GetAsync(
        Expression<Func<ProfileLanguage, bool>> predicate,
        Func<IQueryable<ProfileLanguage>, IIncludableQueryable<ProfileLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileLanguage? profileLanguage = await _profileLanguageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileLanguage;
    }

    public async Task<IPaginate<ProfileLanguage>?> GetListAsync(
        Expression<Func<ProfileLanguage, bool>>? predicate = null,
        Func<IQueryable<ProfileLanguage>, IOrderedQueryable<ProfileLanguage>>? orderBy = null,
        Func<IQueryable<ProfileLanguage>, IIncludableQueryable<ProfileLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileLanguage> profileLanguageList = await _profileLanguageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileLanguageList;
    }

    public async Task<ProfileLanguage> AddAsync(ProfileLanguage profileLanguage)
    {
        ProfileLanguage addedProfileLanguage = await _profileLanguageRepository.AddAsync(profileLanguage);

        return addedProfileLanguage;
    }

    public async Task<ProfileLanguage> UpdateAsync(ProfileLanguage profileLanguage)
    {
        ProfileLanguage updatedProfileLanguage = await _profileLanguageRepository.UpdateAsync(profileLanguage);

        return updatedProfileLanguage;
    }

    public async Task<ProfileLanguage> DeleteAsync(ProfileLanguage profileLanguage, bool permanent = false)
    {
        ProfileLanguage deletedProfileLanguage = await _profileLanguageRepository.DeleteAsync(profileLanguage);

        return deletedProfileLanguage;
    }
}
