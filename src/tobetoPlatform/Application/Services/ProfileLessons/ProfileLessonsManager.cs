using Application.Features.ProfileLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileLessons;

public class ProfileLessonsManager : IProfileLessonsService
{
    private readonly IProfileLessonRepository _profileLessonRepository;
    private readonly ProfileLessonBusinessRules _profileLessonBusinessRules;

    public ProfileLessonsManager(IProfileLessonRepository profileLessonRepository, ProfileLessonBusinessRules profileLessonBusinessRules)
    {
        _profileLessonRepository = profileLessonRepository;
        _profileLessonBusinessRules = profileLessonBusinessRules;
    }

    public async Task<ProfileLesson?> GetAsync(
        Expression<Func<ProfileLesson, bool>> predicate,
        Func<IQueryable<ProfileLesson>, IIncludableQueryable<ProfileLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileLesson? profileLesson = await _profileLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileLesson;
    }

    public async Task<IPaginate<ProfileLesson>?> GetListAsync(
        Expression<Func<ProfileLesson, bool>>? predicate = null,
        Func<IQueryable<ProfileLesson>, IOrderedQueryable<ProfileLesson>>? orderBy = null,
        Func<IQueryable<ProfileLesson>, IIncludableQueryable<ProfileLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileLesson> profileLessonList = await _profileLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileLessonList;
    }

    public async Task<ProfileLesson> AddAsync(ProfileLesson profileLesson)
    {
        ProfileLesson addedProfileLesson = await _profileLessonRepository.AddAsync(profileLesson);

        return addedProfileLesson;
    }

    public async Task<ProfileLesson> UpdateAsync(ProfileLesson profileLesson)
    {
        ProfileLesson updatedProfileLesson = await _profileLessonRepository.UpdateAsync(profileLesson);

        return updatedProfileLesson;
    }

    public async Task<ProfileLesson> DeleteAsync(ProfileLesson profileLesson, bool permanent = false)
    {
        ProfileLesson deletedProfileLesson = await _profileLessonRepository.DeleteAsync(profileLesson);

        return deletedProfileLesson;
    }
}
