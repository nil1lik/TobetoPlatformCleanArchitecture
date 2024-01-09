using Application.Features.VideoLanguages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.VideoLanguages.Rules;

public class VideoLanguageBusinessRules : BaseBusinessRules
{
    private readonly IVideoLanguageRepository _videoLanguageRepository;

    public VideoLanguageBusinessRules(IVideoLanguageRepository videoLanguageRepository)
    {
        _videoLanguageRepository = videoLanguageRepository;
    }

    public Task VideoLanguageShouldExistWhenSelected(VideoLanguage? videoLanguage)
    {
        if (videoLanguage == null)
            throw new BusinessException(VideoLanguagesBusinessMessages.VideoLanguageNotExists);
        return Task.CompletedTask;
    }

    public async Task VideoLanguageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        VideoLanguage? videoLanguage = await _videoLanguageRepository.GetAsync(
            predicate: vl => vl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VideoLanguageShouldExistWhenSelected(videoLanguage);
    }
}