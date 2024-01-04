using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CalendarRepository : EfRepositoryBase<Calendar, int, BaseDbContext>, ICalendarRepository
{
    public CalendarRepository(BaseDbContext context) : base(context)
    {
    }
}