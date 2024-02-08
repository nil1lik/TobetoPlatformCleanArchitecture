using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VideoDetailCategoryRepository : EfRepositoryBase<VideoDetailCategory, int, BaseDbContext>, IVideoDetailCategoryRepository
{
    public VideoDetailCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}