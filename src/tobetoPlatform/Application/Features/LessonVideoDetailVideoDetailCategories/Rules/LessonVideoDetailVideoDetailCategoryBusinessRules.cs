using Application.Features.LessonVideoDetailVideoDetailCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Rules;

public class LessonVideoDetailVideoDetailCategoryBusinessRules : BaseBusinessRules
{
    private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;

    public LessonVideoDetailVideoDetailCategoryBusinessRules(ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository)
    {
        _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
    }

    public Task LessonVideoDetailVideoDetailCategoryShouldExistWhenSelected(LessonVideoDetailVideoDetailCategory? lessonVideoDetailVideoDetailCategory)
    {
        if (lessonVideoDetailVideoDetailCategory == null)
            throw new BusinessException(LessonVideoDetailVideoDetailCategoriesBusinessMessages.LessonVideoDetailVideoDetailCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task LessonVideoDetailVideoDetailCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonVideoDetailVideoDetailCategory? lessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.GetAsync(
            predicate: lvdvdc => lvdvdc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonVideoDetailVideoDetailCategoryShouldExistWhenSelected(lessonVideoDetailVideoDetailCategory);
    }
}