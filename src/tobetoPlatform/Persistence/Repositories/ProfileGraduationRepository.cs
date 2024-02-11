using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileGraduationRepository : EfRepositoryBase<ProfileGraduation, int, BaseDbContext>, IProfileGraduationRepository
{
    public ProfileGraduationRepository(BaseDbContext context) : base(context)
    {
    }
}