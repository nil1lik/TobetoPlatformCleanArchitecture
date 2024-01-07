using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEducationAboutRepository : IAsyncRepository<EducationAbout, int>, IRepository<EducationAbout, int>
{
}