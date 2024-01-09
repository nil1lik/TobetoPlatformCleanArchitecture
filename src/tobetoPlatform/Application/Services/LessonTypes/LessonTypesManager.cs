using Application.Features.LessonTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonTypes;

public class LessonTypesManager : ILessonTypesService
{
    private readonly ILessonTypeRepository _lessonTypeRepository;
    private readonly LessonTypeBusinessRules _lessonTypeBusinessRules;

    public LessonTypesManager(ILessonTypeRepository lessonTypeRepository, LessonTypeBusinessRules lessonTypeBusinessRules)
    {
        _lessonTypeRepository = lessonTypeRepository;
        _lessonTypeBusinessRules = lessonTypeBusinessRules;
    }

    public async Task<LessonType?> GetAsync(
        Expression<Func<LessonType, bool>> predicate,
        Func<IQueryable<LessonType>, IIncludableQueryable<LessonType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonType? lessonType = await _lessonTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonType;
    }

    public async Task<IPaginate<LessonType>?> GetListAsync(
        Expression<Func<LessonType, bool>>? predicate = null,
        Func<IQueryable<LessonType>, IOrderedQueryable<LessonType>>? orderBy = null,
        Func<IQueryable<LessonType>, IIncludableQueryable<LessonType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonType> lessonTypeList = await _lessonTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonTypeList;
    }

    public async Task<LessonType> AddAsync(LessonType lessonType)
    {
        LessonType addedLessonType = await _lessonTypeRepository.AddAsync(lessonType);

        return addedLessonType;
    }

    public async Task<LessonType> UpdateAsync(LessonType lessonType)
    {
        LessonType updatedLessonType = await _lessonTypeRepository.UpdateAsync(lessonType);

        return updatedLessonType;
    }

    public async Task<LessonType> DeleteAsync(LessonType lessonType, bool permanent = false)
    {
        LessonType deletedLessonType = await _lessonTypeRepository.DeleteAsync(lessonType);

        return deletedLessonType;
    }
}
