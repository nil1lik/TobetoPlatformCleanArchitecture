using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AsyncLessonRepository : EfRepositoryBase<AsyncLesson, int, BaseDbContext>, IAsyncLessonRepository
{
    public AsyncLessonRepository(BaseDbContext context) : base(context)
    {
    }
}