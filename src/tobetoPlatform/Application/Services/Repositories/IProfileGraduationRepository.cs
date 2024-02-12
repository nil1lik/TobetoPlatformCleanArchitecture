using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProfileGraduationRepository : IAsyncRepository<ProfileGraduation, int>, IRepository<ProfileGraduation, int>
{
}