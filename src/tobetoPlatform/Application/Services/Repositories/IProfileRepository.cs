using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileRepository : IAsyncRepository<UserProfile, Guid>, IRepository<UserProfile, Guid>
{
}