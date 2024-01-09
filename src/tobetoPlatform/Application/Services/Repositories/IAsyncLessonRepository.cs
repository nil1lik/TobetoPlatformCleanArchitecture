using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAsyncLessonRepository : IAsyncRepository<AsyncLesson, int>, IRepository<AsyncLesson, int>
{
}