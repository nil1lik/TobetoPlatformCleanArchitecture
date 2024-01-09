using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EducationAboutRepository : EfRepositoryBase<EducationAbout, int, BaseDbContext>, IEducationAboutRepository
{
    public EducationAboutRepository(BaseDbContext context) : base(context)
    {
    }
}