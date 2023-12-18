using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExamResultRepository : EfRepositoryBase<ExamResult, int, BaseDbContext>, IExamResultRepository
{
    public ExamResultRepository(BaseDbContext context) : base(context)
    {
    }
}