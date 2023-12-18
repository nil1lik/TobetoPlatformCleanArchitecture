using Application.Features.ExamResults.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExamResults;

public class ExamResultsManager : IExamResultsService
{
    private readonly IExamResultRepository _examResultRepository;
    private readonly ExamResultBusinessRules _examResultBusinessRules;

    public ExamResultsManager(IExamResultRepository examResultRepository, ExamResultBusinessRules examResultBusinessRules)
    {
        _examResultRepository = examResultRepository;
        _examResultBusinessRules = examResultBusinessRules;
    }

    public async Task<ExamResult?> GetAsync(
        Expression<Func<ExamResult, bool>> predicate,
        Func<IQueryable<ExamResult>, IIncludableQueryable<ExamResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ExamResult? examResult = await _examResultRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return examResult;
    }

    public async Task<IPaginate<ExamResult>?> GetListAsync(
        Expression<Func<ExamResult, bool>>? predicate = null,
        Func<IQueryable<ExamResult>, IOrderedQueryable<ExamResult>>? orderBy = null,
        Func<IQueryable<ExamResult>, IIncludableQueryable<ExamResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ExamResult> examResultList = await _examResultRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return examResultList;
    }

    public async Task<ExamResult> AddAsync(ExamResult examResult)
    {
        ExamResult addedExamResult = await _examResultRepository.AddAsync(examResult);

        return addedExamResult;
    }

    public async Task<ExamResult> UpdateAsync(ExamResult examResult)
    {
        ExamResult updatedExamResult = await _examResultRepository.UpdateAsync(examResult);

        return updatedExamResult;
    }

    public async Task<ExamResult> DeleteAsync(ExamResult examResult, bool permanent = false)
    {
        ExamResult deletedExamResult = await _examResultRepository.DeleteAsync(examResult);

        return deletedExamResult;
    }
}
