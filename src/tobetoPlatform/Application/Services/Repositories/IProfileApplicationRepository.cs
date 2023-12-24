using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileApplicationRepository : IAsyncRepository<ProfileApplication, int>, IRepository<ProfileApplication, int>
{
}