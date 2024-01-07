using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISocialMediaCategoryRepository : IAsyncRepository<SocialMediaCategory, int>, IRepository<SocialMediaCategory, int>
{
}