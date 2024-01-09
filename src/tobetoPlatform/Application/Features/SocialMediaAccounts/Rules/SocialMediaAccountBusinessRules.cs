using Application.Features.SocialMediaAccounts.Commands.Create;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using Nest;
using System.Threading;

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


    public async Task CheckUserSocialMediaAccountLimit(int userId)
    {
        IPaginate<SocialMediaAccount> result = await _socialMediaAccountRepository.GetListAsync(b => b.UserProfileId == userId);
        if (result.Count >= 3)
            throw new BusinessException(SocialMediaAccountsBusinessMessages.SocialMediaAccountsCannotBeMoreThan3);
    }


    public async Task SocialMediaAccountsShouldNotBeTheSame(int id, SocialMediaAccount? socialMediaAccount)
    {
        IPaginate<SocialMediaAccount> result = await _socialMediaAccountRepository.GetListAsync(b => b.Id == id);

        if (result.Items.Any() && socialMediaAccount != null && socialMediaAccount.MediaUrl == result.Items.First().MediaUrl)
        {
            throw new BusinessException(SocialMediaAccountsBusinessMessages.SocialMediaAccountsShouldNotBeTheSame);
        }
    }






}