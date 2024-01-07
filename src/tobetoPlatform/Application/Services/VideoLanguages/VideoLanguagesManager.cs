using Application.Features.VideoLanguages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VideoLanguages;

public class VideoLanguagesManager : IVideoLanguagesService
{
    private readonly IVideoLanguageRepository _videoLanguageRepository;
    private readonly VideoLanguageBusinessRules _videoLanguageBusinessRules;

    public VideoLanguagesManager(IVideoLanguageRepository videoLanguageRepository, VideoLanguageBusinessRules videoLanguageBusinessRules)
    {
        _videoLanguageRepository = videoLanguageRepository;
        _videoLanguageBusinessRules = videoLanguageBusinessRules;
    }

    public async Task<VideoLanguage?> GetAsync(
        Expression<Func<VideoLanguage, bool>> predicate,
        Func<IQueryable<VideoLanguage>, IIncludableQueryable<VideoLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        VideoLanguage? videoLanguage = await _videoLanguageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return videoLanguage;
    }

    public async Task<IPaginate<VideoLanguage>?> GetListAsync(
        Expression<Func<VideoLanguage, bool>>? predicate = null,
        Func<IQueryable<VideoLanguage>, IOrderedQueryable<VideoLanguage>>? orderBy = null,
        Func<IQueryable<VideoLanguage>, IIncludableQueryable<VideoLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<VideoLanguage> videoLanguageList = await _videoLanguageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return videoLanguageList;
    }

    public async Task<VideoLanguage> AddAsync(VideoLanguage videoLanguage)
    {
        VideoLanguage addedVideoLanguage = await _videoLanguageRepository.AddAsync(videoLanguage);

        return addedVideoLanguage;
    }

    public async Task<VideoLanguage> UpdateAsync(VideoLanguage videoLanguage)
    {
        VideoLanguage updatedVideoLanguage = await _videoLanguageRepository.UpdateAsync(videoLanguage);

        return updatedVideoLanguage;
    }

    public async Task<VideoLanguage> DeleteAsync(VideoLanguage videoLanguage, bool permanent = false)
    {
        VideoLanguage deletedVideoLanguage = await _videoLanguageRepository.DeleteAsync(videoLanguage);

        return deletedVideoLanguage;
    }
}
