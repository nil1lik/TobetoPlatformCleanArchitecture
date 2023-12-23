using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileApplicationFormRepository : IAsyncRepository<ProfileApplicationForm, int>, IRepository<ProfileApplicationForm, int>
{
}