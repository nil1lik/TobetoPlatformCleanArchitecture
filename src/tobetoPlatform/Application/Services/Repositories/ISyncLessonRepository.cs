using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISyncLessonRepository : IAsyncRepository<SyncLesson, int>, IRepository<SyncLesson, int>
{
}