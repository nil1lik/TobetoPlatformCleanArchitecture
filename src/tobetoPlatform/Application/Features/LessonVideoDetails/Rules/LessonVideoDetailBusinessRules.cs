using Application.Features.LessonVideoDetails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LessonVideoDetails.Rules;

public class LessonVideoDetailBusinessRules : BaseBusinessRules
{
    private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;

    public LessonVideoDetailBusinessRules(ILessonVideoDetailRepository lessonVideoDetailRepository)
    {
        _lessonVideoDetailRepository = lessonVideoDetailRepository;
    }

    public Task LessonVideoDetailShouldExistWhenSelected(LessonVideoDetail? lessonVideoDetail)
    {
        if (lessonVideoDetail == null)
            throw new BusinessException(LessonVideoDetailsBusinessMessages.LessonVideoDetailNotExists);
        return Task.CompletedTask;
    }

    public async Task LessonVideoDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonVideoDetail? lessonVideoDetail = await _lessonVideoDetailRepository.GetAsync(
            predicate: lvd => lvd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonVideoDetailShouldExistWhenSelected(lessonVideoDetail);
    }
}