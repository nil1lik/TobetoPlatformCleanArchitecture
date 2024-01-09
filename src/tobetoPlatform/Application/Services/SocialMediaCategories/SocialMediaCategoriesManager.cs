using Application.Features.SocialMediaCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialMediaCategories;

public class SocialMediaCategoriesManager : ISocialMediaCategoriesService
{
    private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;
    private readonly SocialMediaCategoryBusinessRules _socialMediaCategoryBusinessRules;

    public SocialMediaCategoriesManager(ISocialMediaCategoryRepository socialMediaCategoryRepository, SocialMediaCategoryBusinessRules socialMediaCategoryBusinessRules)
    {
        _socialMediaCategoryRepository = socialMediaCategoryRepository;
        _socialMediaCategoryBusinessRules = socialMediaCategoryBusinessRules;
    }

    public async Task<SocialMediaCategory?> GetAsync(
        Expression<Func<SocialMediaCategory, bool>> predicate,
        Func<IQueryable<SocialMediaCategory>, IIncludableQueryable<SocialMediaCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SocialMediaCategory? socialMediaCategory = await _socialMediaCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return socialMediaCategory;
    }

    public async Task<IPaginate<SocialMediaCategory>?> GetListAsync(
        Expression<Func<SocialMediaCategory, bool>>? predicate = null,
        Func<IQueryable<SocialMediaCategory>, IOrderedQueryable<SocialMediaCategory>>? orderBy = null,
        Func<IQueryable<SocialMediaCategory>, IIncludableQueryable<SocialMediaCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SocialMediaCategory> socialMediaCategoryList = await _socialMediaCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return socialMediaCategoryList;
    }

    public async Task<SocialMediaCategory> AddAsync(SocialMediaCategory socialMediaCategory)
    {
        SocialMediaCategory addedSocialMediaCategory = await _socialMediaCategoryRepository.AddAsync(socialMediaCategory);

        return addedSocialMediaCategory;
    }

    public async Task<SocialMediaCategory> UpdateAsync(SocialMediaCategory socialMediaCategory)
    {
        SocialMediaCategory updatedSocialMediaCategory = await _socialMediaCategoryRepository.UpdateAsync(socialMediaCategory);

        return updatedSocialMediaCategory;
    }

    public async Task<SocialMediaCategory> DeleteAsync(SocialMediaCategory socialMediaCategory, bool permanent = false)
    {
        SocialMediaCategory deletedSocialMediaCategory = await _socialMediaCategoryRepository.DeleteAsync(socialMediaCategory);

        return deletedSocialMediaCategory;
    }
}
