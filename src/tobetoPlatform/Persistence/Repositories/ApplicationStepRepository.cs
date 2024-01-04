using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationStepRepository : EfRepositoryBase<ApplicationStep, int, BaseDbContext>, IApplicationStepRepository
{
    public ApplicationStepRepository(BaseDbContext context) : base(context)
    {
    }
}