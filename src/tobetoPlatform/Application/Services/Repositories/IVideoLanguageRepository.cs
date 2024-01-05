using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVideoLanguageRepository : IAsyncRepository<VideoLanguage, int>, IRepository<VideoLanguage, int>
{
}