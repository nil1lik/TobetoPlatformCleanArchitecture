using Application.Features.VideoDetailSubcategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoDetailSubcategories;

public class VideoDetailSubcategoriesManager : IVideoDetailSubcategoriesService
{
    private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;
    private readonly VideoDetailSubcategoryBusinessRules _videoDetailSubcategoryBusinessRules;

    public VideoDetailSubcategoriesManager(IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository, VideoDetailSubcategoryBusinessRules videoDetailSubcategoryBusinessRules)
    {
        _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
        _videoDetailSubcategoryBusinessRules = videoDetailSubcategoryBusinessRules;
    }

    public async Task<VideoDetailSubcategory?> GetAsync(
        Expression<Func<VideoDetailSubcategory, bool>> predicate,
        Func<IQueryable<VideoDetailSubcategory>, IIncludableQueryable<VideoDetailSubcategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        VideoDetailSubcategory? videoDetailSubcategory = await _videoDetailSubcategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return videoDetailSubcategory;
    }

    public async Task<IPaginate<VideoDetailSubcategory>?> GetListAsync(
        Expression<Func<VideoDetailSubcategory, bool>>? predicate = null,
        Func<IQueryable<VideoDetailSubcategory>, IOrderedQueryable<VideoDetailSubcategory>>? orderBy = null,
        Func<IQueryable<VideoDetailSubcategory>, IIncludableQueryable<VideoDetailSubcategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<VideoDetailSubcategory> videoDetailSubcategoryList = await _videoDetailSubcategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return videoDetailSubcategoryList;
    }

    public async Task<VideoDetailSubcategory> AddAsync(VideoDetailSubcategory videoDetailSubcategory)
    {
        VideoDetailSubcategory addedVideoDetailSubcategory = await _videoDetailSubcategoryRepository.AddAsync(videoDetailSubcategory);

        return addedVideoDetailSubcategory;
    }

    public async Task<VideoDetailSubcategory> UpdateAsync(VideoDetailSubcategory videoDetailSubcategory)
    {
        VideoDetailSubcategory updatedVideoDetailSubcategory = await _videoDetailSubcategoryRepository.UpdateAsync(videoDetailSubcategory);

        return updatedVideoDetailSubcategory;
    }

    public async Task<VideoDetailSubcategory> DeleteAsync(VideoDetailSubcategory videoDetailSubcategory, bool permanent = false)
    {
        VideoDetailSubcategory deletedVideoDetailSubcategory = await _videoDetailSubcategoryRepository.DeleteAsync(videoDetailSubcategory);

        return deletedVideoDetailSubcategory;
    }
}
