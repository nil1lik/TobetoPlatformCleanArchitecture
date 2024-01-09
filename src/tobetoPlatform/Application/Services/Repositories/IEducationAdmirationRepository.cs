using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEducationAdmirationRepository : IAsyncRepository<EducationAdmiration, int>, IRepository<EducationAdmiration, int>
{
}