using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseClassRepository : IAsyncRepository<CourseClass, int>, IRepository<CourseClass, int>
{
}