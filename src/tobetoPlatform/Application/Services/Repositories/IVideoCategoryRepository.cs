using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVideoCategoryRepository : IAsyncRepository<VideoCategory, int>, IRepository<VideoCategory, int>
{
}