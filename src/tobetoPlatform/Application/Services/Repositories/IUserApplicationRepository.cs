using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserApplicationRepository : IAsyncRepository<UserApplication, int>, IRepository<UserApplication, int>
{
}