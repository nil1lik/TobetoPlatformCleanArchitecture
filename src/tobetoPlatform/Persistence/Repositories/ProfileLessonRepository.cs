using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileLessonRepository : EfRepositoryBase<ProfileLesson, int, BaseDbContext>, IProfileLessonRepository
{
    public ProfileLessonRepository(BaseDbContext context) : base(context)
    {
    }
}