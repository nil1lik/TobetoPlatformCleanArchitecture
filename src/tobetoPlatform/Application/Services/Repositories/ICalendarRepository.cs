using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICalendarRepository : IAsyncRepository<Calendar, int>, IRepository<Calendar, int>
{
}