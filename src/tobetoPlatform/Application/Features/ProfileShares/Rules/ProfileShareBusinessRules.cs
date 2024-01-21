using Application.Features.ProfileShares.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MimeKit.Encodings;
using Nest;
using System.Threading;
using ZstdSharp;

namespace Application.Features.ProfileShares.Rules;

public class ProfileShareBusinessRules : BaseBusinessRules
{
    private readonly IProfileShareRepository _profileShareRepository;

    public ProfileShareBusinessRules(IProfileShareRepository profileShareRepository)
    {
        _profileShareRepository = profileShareRepository;
    }

    public Task ProfileShareShouldExistWhenSelected(ProfileShare? profileShare)
    {
        if (profileShare == null)
            throw new BusinessException(ProfileSharesBusinessMessages.ProfileShareNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileShareIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileShare? profileShare = await _profileShareRepository.GetAsync(
            predicate: ps => ps.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileShareShouldExistWhenSelected(profileShare);
    }
}