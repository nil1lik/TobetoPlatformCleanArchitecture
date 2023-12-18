using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationFormRepository : IAsyncRepository<ApplicationForm, int>, IRepository<ApplicationForm, int>
{
}