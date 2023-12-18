using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILanguageRepository : IAsyncRepository<Language, int>, IRepository<Language, int>
{
}