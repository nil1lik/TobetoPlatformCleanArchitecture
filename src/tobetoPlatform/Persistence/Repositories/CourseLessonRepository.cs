using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseLessonRepository : EfRepositoryBase<CourseLesson, int, BaseDbContext>, ICourseLessonRepository
{
    public CourseLessonRepository(BaseDbContext context) : base(context)
    {
    }
}