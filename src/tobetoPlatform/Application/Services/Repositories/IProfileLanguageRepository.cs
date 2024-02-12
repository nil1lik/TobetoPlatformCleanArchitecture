using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileLanguageRepository : IAsyncRepository<ProfileLanguage, int>, IRepository<ProfileLanguage, int>
{
}