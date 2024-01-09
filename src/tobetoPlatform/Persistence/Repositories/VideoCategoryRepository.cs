using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VideoCategoryRepository : EfRepositoryBase<VideoCategory, int, BaseDbContext>, IVideoCategoryRepository
{
    public VideoCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}