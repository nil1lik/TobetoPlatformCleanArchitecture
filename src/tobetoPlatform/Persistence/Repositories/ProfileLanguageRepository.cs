using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProfileLanguageRepository : EfRepositoryBase<ProfileLanguage, int, BaseDbContext>, IProfileLanguageRepository
{
    public ProfileLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}