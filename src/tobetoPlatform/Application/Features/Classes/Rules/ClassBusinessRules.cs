using Application.Features.Classes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Classes.Rules;

public class ClassBusinessRules : BaseBusinessRules
{
    private readonly IClassRepository _classRepository;

    public ClassBusinessRules(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public Task ClassShouldExistWhenSelected(Class? class)
    {
        if (class == null)
            throw new BusinessException(ClassesBusinessMessages.ClassNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Class? class = await _classRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassShouldExistWhenSelected(class);
    }
}