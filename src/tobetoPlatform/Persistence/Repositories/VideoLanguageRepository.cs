using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VideoLanguageRepository : EfRepositoryBase<VideoLanguage, int, BaseDbContext>, IVideoLanguageRepository
{
    public VideoLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}