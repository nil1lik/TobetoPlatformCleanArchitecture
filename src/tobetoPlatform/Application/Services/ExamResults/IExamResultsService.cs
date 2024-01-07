using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExamResults;

public interface IExamResultsService
{
    Task<ExamResult?> GetAsync(
        Expression<Func<ExamResult, bool>> predicate,
        Func<IQueryable<ExamResult>, IIncludableQueryable<ExamResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ExamResult>?> GetListAsync(
        Expression<Func<ExamResult, bool>>? predicate = null,
        Func<IQueryable<ExamResult>, IOrderedQueryable<ExamResult>>? orderBy = null,
        Func<IQueryable<ExamResult>, IIncludableQueryable<ExamResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ExamResult> AddAsync(ExamResult examResult);
    Task<ExamResult> UpdateAsync(ExamResult examResult);
    Task<ExamResult> DeleteAsync(ExamResult examResult, bool permanent = false);
}
