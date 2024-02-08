using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVideoDetailCategoryRepository : IAsyncRepository<VideoDetailCategory, int>, IRepository<VideoDetailCategory, int>
{
}