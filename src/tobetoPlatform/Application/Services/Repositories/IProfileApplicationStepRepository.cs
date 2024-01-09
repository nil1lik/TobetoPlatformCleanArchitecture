using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileApplicationStepRepository : IAsyncRepository<ProfileApplicationStep, int>, IRepository<ProfileApplicationStep, int>
{
}