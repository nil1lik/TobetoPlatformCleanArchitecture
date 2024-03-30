using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileAdmirationRepository : IAsyncRepository<ProfileAdmiration, int>, IRepository<ProfileAdmiration, int>
{
}