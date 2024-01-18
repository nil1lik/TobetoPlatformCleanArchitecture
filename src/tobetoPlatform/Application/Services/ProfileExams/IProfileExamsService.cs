using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileExams;

public interface IProfileExamsService
{
    Task<ProfileExam?> GetAsync(
        Expression<Func<ProfileExam, bool>> predicate,
        Func<IQueryable<ProfileExam>, IIncludableQueryable<ProfileExam, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProfileExam>?> GetListAsync(
        Expression<Func<ProfileExam, bool>>? predicate = null,
        Func<IQueryable<ProfileExam>, IOrderedQueryable<ProfileExam>>? orderBy = null,
        Func<IQueryable<ProfileExam>, IIncludableQueryable<ProfileExam, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProfileExam> AddAsync(ProfileExam profileExam);
    Task<ProfileExam> UpdateAsync(ProfileExam profileExam);
    Task<ProfileExam> DeleteAsync(ProfileExam profileExam, bool permanent = false);
}
