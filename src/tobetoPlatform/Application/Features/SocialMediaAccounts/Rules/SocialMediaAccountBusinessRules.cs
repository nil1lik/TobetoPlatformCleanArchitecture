using Application.Features.SocialMediaAccounts.Commands.Create;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;

namespace Application.Features.SocialMediaAccounts.Rules;

public class SocialMediaAccountBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;

    public SocialMediaAccountBusinessRules(ISocialMediaAccountRepository socialMediaAccountRepository)
    {
        _socialMediaAccountRepository = socialMediaAccountRepository;
    }

    public Task SocialMediaAccountShouldExistWhenSelected(SocialMediaAccount? socialMediaAccount)
    {
        if (socialMediaAccount == null)
            throw new BusinessException(SocialMediaAccountsBusinessMessages.SocialMediaAccountNotExists);
        return Task.CompletedTask;
    }

    public async Task SocialMediaAccountIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(
            predicate: sma => sma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);
    }


    public Task SocialMediaAccountsCannotBeMoreThan3(SocialMediaAccount? socialMediaAccount)
    {
        if (socialMediaAccount.Id >= 3)
            throw new BusinessException(SocialMediaAccountsBusinessMessages.SocialMediaAccountsCannotBeMoreThan3);

        return Task.CompletedTask;
    }



}