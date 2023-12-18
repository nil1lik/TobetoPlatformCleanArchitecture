using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassRepository : IAsyncRepository<CourseClass, int>, IRepository<CourseClass, int>
{
}