using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileEducationRepository : IAsyncRepository<ProfileEducation, int>, IRepository<ProfileEducation, int>
{
}