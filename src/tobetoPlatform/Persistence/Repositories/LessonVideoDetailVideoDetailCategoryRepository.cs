using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonVideoDetailVideoDetailCategoryRepository : EfRepositoryBase<LessonVideoDetailVideoDetailCategory, int, BaseDbContext>, ILessonVideoDetailVideoDetailCategoryRepository
{
    public LessonVideoDetailVideoDetailCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}