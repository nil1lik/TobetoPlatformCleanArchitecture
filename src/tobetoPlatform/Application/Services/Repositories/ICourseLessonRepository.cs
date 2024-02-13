using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseLessonRepository : IAsyncRepository<CourseLesson, int>, IRepository<CourseLesson, int>
{
}