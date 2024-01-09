using Application.Features.VideoCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.VideoCategories.Rules;

public class VideoCategoryBusinessRules : BaseBusinessRules
{
    private readonly IVideoCategoryRepository _videoCategoryRepository;

    public VideoCategoryBusinessRules(IVideoCategoryRepository videoCategoryRepository)
    {
        _videoCategoryRepository = videoCategoryRepository;
    }

    public Task VideoCategoryShouldExistWhenSelected(VideoCategory? videoCategory)
    {
        if (videoCategory == null)
            throw new BusinessException(VideoCategoriesBusinessMessages.VideoCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task VideoCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        VideoCategory? videoCategory = await _videoCategoryRepository.GetAsync(
            predicate: vc => vc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VideoCategoryShouldExistWhenSelected(videoCategory);
    }
}