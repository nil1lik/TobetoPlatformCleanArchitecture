using Application.Features.ExamResults.Constants;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;
using System.Security.Policy;

namespace Application.Features.ExamResults.Rules;

public class ExamResultBusinessRules : BaseBusinessRules
{
    private readonly IExamResultRepository _examResultRepository;

    public ExamResultBusinessRules(IExamResultRepository examResultRepository)
    {
        _examResultRepository = examResultRepository;
    }

    public Task ExamResultShouldExistWhenSelected(ExamResult? examResult)
    {
        if (examResult == null)
            throw new BusinessException(ExamResultsBusinessMessages.ExamResultNotExists);
        return Task.CompletedTask;
    }

    public async Task ExamResultIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ExamResult? examResult = await _examResultRepository.GetAsync(
            predicate: er => er.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ExamResultShouldExistWhenSelected(examResult);
    }

    public async Task OneExamHasOneExamResult(int id, ExamResult? examResult)
    {
        IPaginate<ExamResult> result = await _examResultRepository.GetListAsync(b => b.Id == id);

        if (result.Items.Any() && examResult != null && examResult.ExamId == result.Items.First().ExamId)
        {
            throw new BusinessException(ExamResultsBusinessMessages.OneExamHasOneExamResult);
        }
    }
}