using Domain.Entities;
using Core.Persistence.Repositories;
using Application.Features.ProfileAddresses.Commands.Create;

namespace Application.Services.Repositories;

public interface IProfileAddressRepository : IAsyncRepository<ProfileAddress, int>, IRepository<ProfileAddress, int>
{
    ProfileAddress? GetCreatedProfileAddresss(int userId);
}