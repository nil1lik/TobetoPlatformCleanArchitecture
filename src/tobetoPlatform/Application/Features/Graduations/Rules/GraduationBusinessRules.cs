using Application.Features.Graduations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Graduations.Rules;

public class GraduationBusinessRules : BaseBusinessRules
{
    private readonly IGraduationRepository _graduationRepository;

    public GraduationBusinessRules(IGraduationRepository graduationRepository)
    {
        _graduationRepository = graduationRepository;
    }

    public Task GraduationShouldExistWhenSelected(Graduation? graduation)
    {
        if (graduation == null)
            throw new BusinessException(GraduationsBusinessMessages.GraduationNotExists);
        return Task.CompletedTask;
    }

    public async Task GraduationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Graduation? graduation = await _graduationRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GraduationShouldExistWhenSelected(graduation);
    }
}