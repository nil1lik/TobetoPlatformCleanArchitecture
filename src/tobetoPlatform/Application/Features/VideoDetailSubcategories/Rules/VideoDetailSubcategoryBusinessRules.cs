using Application.Features.VideoDetailSubcategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.VideoDetailSubcategories.Rules;

public class VideoDetailSubcategoryBusinessRules : BaseBusinessRules
{
    private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;

    public VideoDetailSubcategoryBusinessRules(IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository)
    {
        _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
    }

    public Task VideoDetailSubcategoryShouldExistWhenSelected(VideoDetailSubcategory? videoDetailSubcategory)
    {
        if (videoDetailSubcategory == null)
            throw new BusinessException(VideoDetailSubcategoriesBusinessMessages.VideoDetailSubcategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task VideoDetailSubcategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        VideoDetailSubcategory? videoDetailSubcategory = await _videoDetailSubcategoryRepository.GetAsync(
            predicate: vds => vds.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VideoDetailSubcategoryShouldExistWhenSelected(videoDetailSubcategory);
    }
}