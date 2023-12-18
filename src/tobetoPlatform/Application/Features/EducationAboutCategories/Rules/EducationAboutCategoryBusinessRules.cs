using Application.Features.EducationAboutCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EducationAboutCategories.Rules;

public class EducationAboutCategoryBusinessRules : BaseBusinessRules
{
    private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;

    public EducationAboutCategoryBusinessRules(IEducationAboutCategoryRepository educationAboutCategoryRepository)
    {
        _educationAboutCategoryRepository = educationAboutCategoryRepository;
    }

    public Task EducationAboutCategoryShouldExistWhenSelected(EducationAboutCategory? educationAboutCategory)
    {
        if (educationAboutCategory == null)
            throw new BusinessException(EducationAboutCategoriesBusinessMessages.EducationAboutCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task EducationAboutCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        EducationAboutCategory? educationAboutCategory = await _educationAboutCategoryRepository.GetAsync(
            predicate: eac => eac.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EducationAboutCategoryShouldExistWhenSelected(educationAboutCategory);
    }
}