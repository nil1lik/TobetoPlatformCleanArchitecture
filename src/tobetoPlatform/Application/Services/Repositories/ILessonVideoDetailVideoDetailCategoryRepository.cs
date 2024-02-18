using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonVideoDetailVideoDetailCategoryRepository : IAsyncRepository<LessonVideoDetailVideoDetailCategory, int>, IRepository<LessonVideoDetailVideoDetailCategory, int>
{
}