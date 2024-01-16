using Application.Features.ProfileExams.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileExams.Rules;

public class ProfileExamBusinessRules : BaseBusinessRules
{
    private readonly IProfileExamRepository _profileExamRepository;

    public ProfileExamBusinessRules(IProfileExamRepository profileExamRepository)
    {
        _profileExamRepository = profileExamRepository;
    }

    public Task ProfileExamShouldExistWhenSelected(ProfileExam? profileExam)
    {
        if (profileExam == null)
            throw new BusinessException(ProfileExamsBusinessMessages.ProfileExamNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileExamIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileExam? profileExam = await _profileExamRepository.GetAsync(
            predicate: pe => pe.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileExamShouldExistWhenSelected(profileExam);
    }
}