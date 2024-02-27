using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileEducationRepository : EfRepositoryBase<ProfileEducation, int, BaseDbContext>, IProfileEducationRepository
{
    public ProfileEducationRepository(BaseDbContext context) : base(context)
    {
    }
}