using Application.Features.ProfileAddresses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileAddresses;

public class ProfileAddressesManager : IProfileAddressesService
{
    private readonly IProfileAddressRepository _profileAddressRepository;
    private readonly ProfileAddressBusinessRules _profileAddressBusinessRules;

    public ProfileAddressesManager(IProfileAddressRepository profileAddressRepository, ProfileAddressBusinessRules profileAddressBusinessRules)
    {
        _profileAddressRepository = profileAddressRepository;
        _profileAddressBusinessRules = profileAddressBusinessRules;
    }

    public async Task<ProfileAddress?> GetAsync(
        Expression<Func<ProfileAddress, bool>> predicate,
        Func<IQueryable<ProfileAddress>, IIncludableQueryable<ProfileAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileAddress? profileAddress = await _profileAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileAddress;
    }

    public async Task<IPaginate<ProfileAddress>?> GetListAsync(
        Expression<Func<ProfileAddress, bool>>? predicate = null,
        Func<IQueryable<ProfileAddress>, IOrderedQueryable<ProfileAddress>>? orderBy = null,
        Func<IQueryable<ProfileAddress>, IIncludableQueryable<ProfileAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileAddress> profileAddressList = await _profileAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileAddressList;
    }

    public async Task<ProfileAddress> AddAsync(ProfileAddress profileAddress)
    {
        ProfileAddress addedProfileAddress = await _profileAddressRepository.AddAsync(profileAddress);

        return addedProfileAddress;
    }

    public async Task<ProfileAddress> UpdateAsync(ProfileAddress profileAddress)
    {
        ProfileAddress updatedProfileAddress = await _profileAddressRepository.UpdateAsync(profileAddress);

        return updatedProfileAddress;
    }

    public async Task<ProfileAddress> DeleteAsync(ProfileAddress profileAddress, bool permanent = false)
    {
        ProfileAddress deletedProfileAddress = await _profileAddressRepository.DeleteAsync(profileAddress);

        return deletedProfileAddress;
    }
}
