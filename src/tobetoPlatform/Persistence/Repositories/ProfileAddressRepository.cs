using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;
using Application.Features.ProfileAddresses.Commands.Create;
using Application.Features.UserProfiles.Commands.Create;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProfileAddressRepository : EfRepositoryBase<ProfileAddress, int, BaseDbContext>, IProfileAddressRepository
{
    public ProfileAddressRepository(BaseDbContext context) : base(context)
    {

    }

    public ProfileAddress? GetCreatedProfileAddresss(int userId)
    {
        var x = Context.ProfileAddresses.
            Include(x=>x.City).
            Include(x=>x.Country).
            Include(x=>x.District).
            FirstOrDefault(x=>x.UserProfileId == userId);
        return x;
    }
}