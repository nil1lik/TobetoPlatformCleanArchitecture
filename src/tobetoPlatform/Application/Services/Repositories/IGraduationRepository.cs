using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGraduationRepository : IAsyncRepository<Graduation, int>, IRepository<Graduation, int>
{
}