using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IContactRepository : IAsyncRepository<Contact, int>, IRepository<Contact, int>
{
}