using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileShareRepository : IAsyncRepository<ProfileShare, int>, IRepository<ProfileShare, int>
{
}