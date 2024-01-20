using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseInstructorRepository : EfRepositoryBase<CourseInstructor, int, BaseDbContext>, ICourseInstructorRepository
{
    public CourseInstructorRepository(BaseDbContext context) : base(context)
    {
    }
}