using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileExamRepository : EfRepositoryBase<ProfileExam, int, BaseDbContext>, IProfileExamRepository
{
    public ProfileExamRepository(BaseDbContext context) : base(context)
    {
    }
}