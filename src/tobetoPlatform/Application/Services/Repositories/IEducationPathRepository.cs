using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEducationPathRepository : IAsyncRepository<EducationPath, int>, IRepository<EducationPath, int>
{
}