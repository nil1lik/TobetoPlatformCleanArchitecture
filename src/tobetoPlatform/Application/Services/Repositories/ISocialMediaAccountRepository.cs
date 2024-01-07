using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISocialMediaAccountRepository : IAsyncRepository<SocialMediaAccount, int>, IRepository<SocialMediaAccount, int>
{
}