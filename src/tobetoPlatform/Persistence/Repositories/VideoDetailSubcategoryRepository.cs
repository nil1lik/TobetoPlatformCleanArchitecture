using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VideoDetailSubcategoryRepository : EfRepositoryBase<VideoDetailSubcategory, int, BaseDbContext>, IVideoDetailSubcategoryRepository
{
    public VideoDetailSubcategoryRepository(BaseDbContext context) : base(context)
    {
    }
}