using Application.Features.LessonVideoDetails.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonVideoDetails;

public class LessonVideoDetailsManager : ILessonVideoDetailsService
{
    private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;
    private readonly LessonVideoDetailBusinessRules _lessonVideoDetailBusinessRules;

    public LessonVideoDetailsManager(ILessonVideoDetailRepository lessonVideoDetailRepository, LessonVideoDetailBusinessRules lessonVideoDetailBusinessRules)
    {
        _lessonVideoDetailRepository = lessonVideoDetailRepository;
        _lessonVideoDetailBusinessRules = lessonVideoDetailBusinessRules;
    }

    public async Task<LessonVideoDetail?> GetAsync(
        Expression<Func<LessonVideoDetail, bool>> predicate,
        Func<IQueryable<LessonVideoDetail>, IIncludableQueryable<LessonVideoDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonVideoDetail? lessonVideoDetail = await _lessonVideoDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonVideoDetail;
    }

    public async Task<IPaginate<LessonVideoDetail>?> GetListAsync(
        Expression<Func<LessonVideoDetail, bool>>? predicate = null,
        Func<IQueryable<LessonVideoDetail>, IOrderedQueryable<LessonVideoDetail>>? orderBy = null,
        Func<IQueryable<LessonVideoDetail>, IIncludableQueryable<LessonVideoDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonVideoDetail> lessonVideoDetailList = await _lessonVideoDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonVideoDetailList;
    }

    public async Task<LessonVideoDetail> AddAsync(LessonVideoDetail lessonVideoDetail)
    {
        LessonVideoDetail addedLessonVideoDetail = await _lessonVideoDetailRepository.AddAsync(lessonVideoDetail);

        return addedLessonVideoDetail;
    }

    public async Task<LessonVideoDetail> UpdateAsync(LessonVideoDetail lessonVideoDetail)
    {
        LessonVideoDetail updatedLessonVideoDetail = await _lessonVideoDetailRepository.UpdateAsync(lessonVideoDetail);

        return updatedLessonVideoDetail;
    }

    public async Task<LessonVideoDetail> DeleteAsync(LessonVideoDetail lessonVideoDetail, bool permanent = false)
    {
        LessonVideoDetail deletedLessonVideoDetail = await _lessonVideoDetailRepository.DeleteAsync(lessonVideoDetail);

        return deletedLessonVideoDetail;
    }
}
