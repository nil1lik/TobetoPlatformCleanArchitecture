using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonVideoDetailRepository : EfRepositoryBase<LessonVideoDetail, int, BaseDbContext>, ILessonVideoDetailRepository
{
    public LessonVideoDetailRepository(BaseDbContext context) : base(context)
    {
    }
}