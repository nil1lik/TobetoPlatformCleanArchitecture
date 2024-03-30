using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileLessons;

public interface IProfileLessonsService
{
    Task<ProfileLesson?> GetAsync(
        Expression<Func<ProfileLesson, bool>> predicate,
        Func<IQueryable<ProfileLesson>, IIncludableQueryable<ProfileLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileLesson>?> GetListAsync(
        Expression<Func<ProfileLesson, bool>>? predicate = null,
        Func<IQueryable<ProfileLesson>, IOrderedQueryable<ProfileLesson>>? orderBy = null,
        Func<IQueryable<ProfileLesson>, IIncludableQueryable<ProfileLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileLesson> AddAsync(ProfileLesson profileLesson);
    Task<ProfileLesson> UpdateAsync(ProfileLesson profileLesson);
    Task<ProfileLesson> DeleteAsync(ProfileLesson profileLesson, bool permanent = false);
}
