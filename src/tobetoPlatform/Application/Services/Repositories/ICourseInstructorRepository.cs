using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseInstructorRepository : IAsyncRepository<CourseInstructor, int>, IRepository<CourseInstructor, int>
{
}