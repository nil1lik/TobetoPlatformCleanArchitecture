using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationStepRepository : IAsyncRepository<ApplicationStep, int>, IRepository<ApplicationStep, int>
{
}