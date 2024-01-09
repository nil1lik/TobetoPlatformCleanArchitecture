using Application.Features.UserApplications.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserApplications.Rules;

public class UserApplicationBusinessRules : BaseBusinessRules
{
    private readonly IUserApplicationRepository _userApplicationRepository;

    public UserApplicationBusinessRules(IUserApplicationRepository userApplicationRepository)
    {
        _userApplicationRepository = userApplicationRepository;
    }

    public Task UserApplicationShouldExistWhenSelected(UserApplication? userApplication)
    {
        if (userApplication == null)
            throw new BusinessException(UserApplicationsBusinessMessages.UserApplicationNotExists);
        return Task.CompletedTask;
    }

    public async Task UserApplicationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserApplication? userApplication = await _userApplicationRepository.GetAsync(
            predicate: ua => ua.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserApplicationShouldExistWhenSelected(userApplication);
    }
}