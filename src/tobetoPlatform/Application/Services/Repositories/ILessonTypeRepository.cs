using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonTypeRepository : IAsyncRepository<LessonType, int>, IRepository<LessonType, int>
{
}