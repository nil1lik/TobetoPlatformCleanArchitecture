using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileClassRepository : IAsyncRepository<ProfileClass, int>, IRepository<ProfileClass, int>
{
}