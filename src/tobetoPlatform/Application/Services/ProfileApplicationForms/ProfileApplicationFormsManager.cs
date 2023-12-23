using Application.Features.ProfileApplicationForms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileApplicationForms;

public class ProfileApplicationFormsManager : IProfileApplicationFormsService
{
    private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;
    private readonly ProfileApplicationFormBusinessRules _profileApplicationFormBusinessRules;

    public ProfileApplicationFormsManager(IProfileApplicationFormRepository profileApplicationFormRepository, ProfileApplicationFormBusinessRules profileApplicationFormBusinessRules)
    {
        _profileApplicationFormRepository = profileApplicationFormRepository;
        _profileApplicationFormBusinessRules = profileApplicationFormBusinessRules;
    }

    public async Task<ProfileApplicationForm?> GetAsync(
        Expression<Func<ProfileApplicationForm, bool>> predicate,
        Func<IQueryable<ProfileApplicationForm>, IIncludableQueryable<ProfileApplicationForm, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileApplicationForm? profileApplicationForm = await _profileApplicationFormRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileApplicationForm;
    }

    public async Task<IPaginate<ProfileApplicationForm>?> GetListAsync(
        Expression<Func<ProfileApplicationForm, bool>>? predicate = null,
        Func<IQueryable<ProfileApplicationForm>, IOrderedQueryable<ProfileApplicationForm>>? orderBy = null,
        Func<IQueryable<ProfileApplicationForm>, IIncludableQueryable<ProfileApplicationForm, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileApplicationForm> profileApplicationFormList = await _profileApplicationFormRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileApplicationFormList;
    }

    public async Task<ProfileApplicationForm> AddAsync(ProfileApplicationForm profileApplicationForm)
    {
        ProfileApplicationForm addedProfileApplicationForm = await _profileApplicationFormRepository.AddAsync(profileApplicationForm);

        return addedProfileApplicationForm;
    }

    public async Task<ProfileApplicationForm> UpdateAsync(ProfileApplicationForm profileApplicationForm)
    {
        ProfileApplicationForm updatedProfileApplicationForm = await _profileApplicationFormRepository.UpdateAsync(profileApplicationForm);

        return updatedProfileApplicationForm;
    }

    public async Task<ProfileApplicationForm> DeleteAsync(ProfileApplicationForm profileApplicationForm, bool permanent = false)
    {
        ProfileApplicationForm deletedProfileApplicationForm = await _profileApplicationFormRepository.DeleteAsync(profileApplicationForm);

        return deletedProfileApplicationForm;
    }
}
