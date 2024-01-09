using Application.Features.SocialMediaCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SocialMediaCategories.Rules;

public class SocialMediaCategoryBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;

    public SocialMediaCategoryBusinessRules(ISocialMediaCategoryRepository socialMediaCategoryRepository)
    {
        _socialMediaCategoryRepository = socialMediaCategoryRepository;
    }

    public Task SocialMediaCategoryShouldExistWhenSelected(SocialMediaCategory? socialMediaCategory)
    {
        if (socialMediaCategory == null)
            throw new BusinessException(SocialMediaCategoriesBusinessMessages.SocialMediaCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task SocialMediaCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SocialMediaCategory? socialMediaCategory = await _socialMediaCategoryRepository.GetAsync(
            predicate: smc => smc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SocialMediaCategoryShouldExistWhenSelected(socialMediaCategory);
    }
}