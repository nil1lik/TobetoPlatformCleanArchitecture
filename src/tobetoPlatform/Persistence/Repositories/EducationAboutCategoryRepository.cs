using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EducationAboutCategoryRepository : EfRepositoryBase<EducationAboutCategory, int, BaseDbContext>, IEducationAboutCategoryRepository
{
    public EducationAboutCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}