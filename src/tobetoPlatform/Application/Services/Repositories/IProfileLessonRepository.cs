using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileLessonRepository : IAsyncRepository<ProfileLesson, int>, IRepository<ProfileLesson, int>
{
}