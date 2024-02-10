using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendars.Queries.GetAllCalendar;
public class GetAllCalenderListItemDto : IDto
{
    public DateTime StartDate { get; set; }
    public string EducationPathName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
