using Application.Features.VideoDetailCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.VideoDetailCategories.Rules;

public class VideoDetailCategoryBusinessRules : BaseBusinessRules
{
    private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;

    public VideoDetailCategoryBusinessRules(IVideoDetailCategoryRepository videoDetailCategoryRepository)
    {
        _videoDetailCategoryRepository = videoDetailCategoryRepository;
    }

    public Task VideoDetailCategoryShouldExistWhenSelected(VideoDetailCategory? videoDetailCategory)
    {
        if (videoDetailCategory == null)
            throw new BusinessException(VideoDetailCategoriesBusinessMessages.VideoDetailCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task VideoDetailCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        VideoDetailCategory? videoDetailCategory = await _videoDetailCategoryRepository.GetAsync(
            predicate: vdc => vdc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VideoDetailCategoryShouldExistWhenSelected(videoDetailCategory);
    }
}