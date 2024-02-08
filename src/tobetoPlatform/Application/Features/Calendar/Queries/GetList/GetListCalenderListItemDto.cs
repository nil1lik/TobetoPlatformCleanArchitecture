using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendar.Queries.GetList;
public class GetListCalenderListItemDto : IDto
{
    public DateTime StartDate{ get; set; } 
    public string CourseName { get; set; }
    public GetListCalendarInstructorItemDto  Instructor { get; set; }

}

public class GetListCalendarInstructorItemDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
