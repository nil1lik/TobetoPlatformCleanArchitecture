using Application.Features.VideoCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoCategories;

public class VideoCategoriesManager : IVideoCategoriesService
{
    private readonly IVideoCategoryRepository _videoCategoryRepository;
    private readonly VideoCategoryBusinessRules _videoCategoryBusinessRules;

    public VideoCategoriesManager(IVideoCategoryRepository videoCategoryRepository, VideoCategoryBusinessRules videoCategoryBusinessRules)
    {
        _videoCategoryRepository = videoCategoryRepository;
        _videoCategoryBusinessRules = videoCategoryBusinessRules;
    }

    public async Task<VideoCategory?> GetAsync(
        Expression<Func<VideoCategory, bool>> predicate,
        Func<IQueryable<VideoCategory>, IIncludableQueryable<VideoCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        VideoCategory? videoCategory = await _videoCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return videoCategory;
    }

    public async Task<IPaginate<VideoCategory>?> GetListAsync(
        Expression<Func<VideoCategory, bool>>? predicate = null,
        Func<IQueryable<VideoCategory>, IOrderedQueryable<VideoCategory>>? orderBy = null,
        Func<IQueryable<VideoCategory>, IIncludableQueryable<VideoCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<VideoCategory> videoCategoryList = await _videoCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return videoCategoryList;
    }

    public async Task<VideoCategory> AddAsync(VideoCategory videoCategory)
    {
        VideoCategory addedVideoCategory = await _videoCategoryRepository.AddAsync(videoCategory);

        return addedVideoCategory;
    }

    public async Task<VideoCategory> UpdateAsync(VideoCategory videoCategory)
    {
        VideoCategory updatedVideoCategory = await _videoCategoryRepository.UpdateAsync(videoCategory);

        return updatedVideoCategory;
    }

    public async Task<VideoCategory> DeleteAsync(VideoCategory videoCategory, bool permanent = false)
    {
        VideoCategory deletedVideoCategory = await _videoCategoryRepository.DeleteAsync(videoCategory);

        return deletedVideoCategory;
    }
}
