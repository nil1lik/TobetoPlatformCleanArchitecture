using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVideoDetailSubcategoryRepository : IAsyncRepository<VideoDetailSubcategory, int>, IRepository<VideoDetailSubcategory, int>
{
}