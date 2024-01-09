using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseClassRepository : EfRepositoryBase<CourseClass, int, BaseDbContext>, ICourseClassRepository
{
    public CourseClassRepository(BaseDbContext context) : base(context)
    {
    }
}