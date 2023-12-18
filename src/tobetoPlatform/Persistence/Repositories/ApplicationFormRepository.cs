using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationFormRepository : EfRepositoryBase<ApplicationForm, int, BaseDbContext>, IApplicationFormRepository
{
    public ApplicationFormRepository(BaseDbContext context) : base(context)
    {
    }
}