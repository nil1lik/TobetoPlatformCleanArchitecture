using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassRepository : IAsyncRepository<Class, int>, IRepository<Class, int>
{
}