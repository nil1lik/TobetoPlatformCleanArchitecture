using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonVideoDetailRepository : IAsyncRepository<LessonVideoDetail, int>, IRepository<LessonVideoDetail, int>
{
}