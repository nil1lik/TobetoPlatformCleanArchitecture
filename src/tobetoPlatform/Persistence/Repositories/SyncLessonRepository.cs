using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SyncLessonRepository : EfRepositoryBase<SyncLesson, int, BaseDbContext>, ISyncLessonRepository
{
    public SyncLessonRepository(BaseDbContext context) : base(context)
    {
    }
}