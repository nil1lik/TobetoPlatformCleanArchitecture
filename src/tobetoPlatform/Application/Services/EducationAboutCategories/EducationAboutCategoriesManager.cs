using Application.Features.EducationAboutCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationAboutCategories;

public class EducationAboutCategoriesManager : IEducationAboutCategoriesService
{
    private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;
    private readonly EducationAboutCategoryBusinessRules _educationAboutCategoryBusinessRules;

    public EducationAboutCategoriesManager(IEducationAboutCategoryRepository educationAboutCategoryRepository, EducationAboutCategoryBusinessRules educationAboutCategoryBusinessRules)
    {
        _educationAboutCategoryRepository = educationAboutCategoryRepository;
        _educationAboutCategoryBusinessRules = educationAboutCategoryBusinessRules;
    }

    public async Task<EducationAboutCategory?> GetAsync(
        Expression<Func<EducationAboutCategory, bool>> predicate,
        Func<IQueryable<EducationAboutCategory>, IIncludableQueryable<EducationAboutCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EducationAboutCategory? educationAboutCategory = await _educationAboutCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return educationAboutCategory;
    }

    public async Task<IPaginate<EducationAboutCategory>?> GetListAsync(
        Expression<Func<EducationAboutCategory, bool>>? predicate = null,
        Func<IQueryable<EducationAboutCategory>, IOrderedQueryable<EducationAboutCategory>>? orderBy = null,
        Func<IQueryable<EducationAboutCategory>, IIncludableQueryable<EducationAboutCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EducationAboutCategory> educationAboutCategoryList = await _educationAboutCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return educationAboutCategoryList;
    }

    public async Task<EducationAboutCategory> AddAsync(EducationAboutCategory educationAboutCategory)
    {
        EducationAboutCategory addedEducationAboutCategory = await _educationAboutCategoryRepository.AddAsync(educationAboutCategory);

        return addedEducationAboutCategory;
    }

    public async Task<EducationAboutCategory> UpdateAsync(EducationAboutCategory educationAboutCategory)
    {
        EducationAboutCategory updatedEducationAboutCategory = await _educationAboutCategoryRepository.UpdateAsync(educationAboutCategory);

        return updatedEducationAboutCategory;
    }

    public async Task<EducationAboutCategory> DeleteAsync(EducationAboutCategory educationAboutCategory, bool permanent = false)
    {
        EducationAboutCategory deletedEducationAboutCategory = await _educationAboutCategoryRepository.DeleteAsync(educationAboutCategory);

        return deletedEducationAboutCategory;
    }
}
