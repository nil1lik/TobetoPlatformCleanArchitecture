using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILanguageLevelRepository : IAsyncRepository<LanguageLevel, int>, IRepository<LanguageLevel, int>
{
}