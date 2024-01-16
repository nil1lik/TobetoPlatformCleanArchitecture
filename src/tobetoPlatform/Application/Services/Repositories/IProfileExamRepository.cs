using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileExamRepository : IAsyncRepository<ProfileExam, int>, IRepository<ProfileExam, int>
{
}