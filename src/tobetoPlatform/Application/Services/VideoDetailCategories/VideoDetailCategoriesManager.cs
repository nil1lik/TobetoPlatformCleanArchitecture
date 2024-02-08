using Application.Features.VideoDetailCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoDetailCategories;

public class VideoDetailCategoriesManager : IVideoDetailCategoriesService
{
    private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;
    private readonly VideoDetailCategoryBusinessRules _videoDetailCategoryBusinessRules;

    public VideoDetailCategoriesManager(IVideoDetailCategoryRepository videoDetailCategoryRepository, VideoDetailCategoryBusinessRules videoDetailCategoryBusinessRules)
    {
        _videoDetailCategoryRepository = videoDetailCategoryRepository;
        _videoDetailCategoryBusinessRules = videoDetailCategoryBusinessRules;
    }

    public async Task<VideoDetailCategory?> GetAsync(
        Expression<Func<VideoDetailCategory, bool>> predicate,
        Func<IQueryable<VideoDetailCategory>, IIncludableQueryable<VideoDetailCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        VideoDetailCategory? videoDetailCategory = await _videoDetailCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return videoDetailCategory;
    }

    public async Task<IPaginate<VideoDetailCategory>?> GetListAsync(
        Expression<Func<VideoDetailCategory, bool>>? predicate = null,
        Func<IQueryable<VideoDetailCategory>, IOrderedQueryable<VideoDetailCategory>>? orderBy = null,
        Func<IQueryable<VideoDetailCategory>, IIncludableQueryable<VideoDetailCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<VideoDetailCategory> videoDetailCategoryList = await _videoDetailCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return videoDetailCategoryList;
    }

    public async Task<VideoDetailCategory> AddAsync(VideoDetailCategory videoDetailCategory)
    {
        VideoDetailCategory addedVideoDetailCategory = await _videoDetailCategoryRepository.AddAsync(videoDetailCategory);

        return addedVideoDetailCategory;
    }

    public async Task<VideoDetailCategory> UpdateAsync(VideoDetailCategory videoDetailCategory)
    {
        VideoDetailCategory updatedVideoDetailCategory = await _videoDetailCategoryRepository.UpdateAsync(videoDetailCategory);

        return updatedVideoDetailCategory;
    }

    public async Task<VideoDetailCategory> DeleteAsync(VideoDetailCategory videoDetailCategory, bool permanent = false)
    {
        VideoDetailCategory deletedVideoDetailCategory = await _videoDetailCategoryRepository.DeleteAsync(videoDetailCategory);

        return deletedVideoDetailCategory;
    }
}
