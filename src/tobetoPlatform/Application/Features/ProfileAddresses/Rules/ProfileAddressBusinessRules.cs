using Application.Features.ProfileAddresses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProfileAddresses.Rules;

public class ProfileAddressBusinessRules : BaseBusinessRules
{
    private readonly IProfileAddressRepository _profileAddressRepository;

    public ProfileAddressBusinessRules(IProfileAddressRepository profileAddressRepository)
    {
        _profileAddressRepository = profileAddressRepository;
    }

    public Task ProfileAddressShouldExistWhenSelected(ProfileAddress? profileAddress)
    {
        if (profileAddress == null)
            throw new BusinessException(ProfileAddressesBusinessMessages.ProfileAddressNotExists);
        return Task.CompletedTask;
    }

    public async Task ProfileAddressIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProfileAddress? profileAddress = await _profileAddressRepository.GetAsync(
            predicate: pa => pa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProfileAddressShouldExistWhenSelected(profileAddress);
    }
}