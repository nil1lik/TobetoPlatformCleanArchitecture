using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEducationAboutCategoryRepository : IAsyncRepository<EducationAboutCategory, int>, IRepository<EducationAboutCategory, int>
{
}