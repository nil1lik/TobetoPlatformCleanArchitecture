using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserProfileRepository : IAsyncRepository<UserProfile, int>, IRepository<UserProfile, int>
{
}