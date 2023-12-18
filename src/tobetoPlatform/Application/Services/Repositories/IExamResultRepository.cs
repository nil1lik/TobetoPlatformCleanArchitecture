using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IExamResultRepository : IAsyncRepository<ExamResult, int>, IRepository<ExamResult, int>
{
}