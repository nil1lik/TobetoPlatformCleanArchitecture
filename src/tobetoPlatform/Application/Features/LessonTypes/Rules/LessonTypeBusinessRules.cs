using Application.Features.LessonTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LessonTypes.Rules;

public class LessonTypeBusinessRules : BaseBusinessRules
{
    private readonly ILessonTypeRepository _lessonTypeRepository;

    public LessonTypeBusinessRules(ILessonTypeRepository lessonTypeRepository)
    {
        _lessonTypeRepository = lessonTypeRepository;
    }

    public Task LessonTypeShouldExistWhenSelected(LessonType? lessonType)
    {
        if (lessonType == null)
            throw new BusinessException(LessonTypesBusinessMessages.LessonTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task LessonTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonType? lessonType = await _lessonTypeRepository.GetAsync(
            predicate: lt => lt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonTypeShouldExistWhenSelected(lessonType);
    }
}