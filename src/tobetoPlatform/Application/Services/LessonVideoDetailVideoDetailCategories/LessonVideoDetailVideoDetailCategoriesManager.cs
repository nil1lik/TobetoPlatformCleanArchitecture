using Application.Features.LessonVideoDetailVideoDetailCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonVideoDetailVideoDetailCategories;

public class LessonVideoDetailVideoDetailCategoriesManager : ILessonVideoDetailVideoDetailCategoriesService
{
    private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;
    private readonly LessonVideoDetailVideoDetailCategoryBusinessRules _lessonVideoDetailVideoDetailCategoryBusinessRules;

    public LessonVideoDetailVideoDetailCategoriesManager(ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository, LessonVideoDetailVideoDetailCategoryBusinessRules lessonVideoDetailVideoDetailCategoryBusinessRules)
    {
        _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
        _lessonVideoDetailVideoDetailCategoryBusinessRules = lessonVideoDetailVideoDetailCategoryBusinessRules;
    }

    public async Task<LessonVideoDetailVideoDetailCategory?> GetAsync(
        Expression<Func<LessonVideoDetailVideoDetailCategory, bool>> predicate,
        Func<IQueryable<LessonVideoDetailVideoDetailCategory>, IIncludableQueryable<LessonVideoDetailVideoDetailCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonVideoDetailVideoDetailCategory? lessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonVideoDetailVideoDetailCategory;
    }

    public async Task<IPaginate<LessonVideoDetailVideoDetailCategory>?> GetListAsync(
        Expression<Func<LessonVideoDetailVideoDetailCategory, bool>>? predicate = null,
        Func<IQueryable<LessonVideoDetailVideoDetailCategory>, IOrderedQueryable<LessonVideoDetailVideoDetailCategory>>? orderBy = null,
        Func<IQueryable<LessonVideoDetailVideoDetailCategory>, IIncludableQueryable<LessonVideoDetailVideoDetailCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonVideoDetailVideoDetailCategory> lessonVideoDetailVideoDetailCategoryList = await _lessonVideoDetailVideoDetailCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonVideoDetailVideoDetailCategoryList;
    }

    public async Task<LessonVideoDetailVideoDetailCategory> AddAsync(LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory)
    {
        LessonVideoDetailVideoDetailCategory addedLessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.AddAsync(lessonVideoDetailVideoDetailCategory);

        return addedLessonVideoDetailVideoDetailCategory;
    }

    public async Task<LessonVideoDetailVideoDetailCategory> UpdateAsync(LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory)
    {
        LessonVideoDetailVideoDetailCategory updatedLessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.UpdateAsync(lessonVideoDetailVideoDetailCategory);

        return updatedLessonVideoDetailVideoDetailCategory;
    }

    public async Task<LessonVideoDetailVideoDetailCategory> DeleteAsync(LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory, bool permanent = false)
    {
        LessonVideoDetailVideoDetailCategory deletedLessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.DeleteAsync(lessonVideoDetailVideoDetailCategory);

        return deletedLessonVideoDetailVideoDetailCategory;
    }
}
