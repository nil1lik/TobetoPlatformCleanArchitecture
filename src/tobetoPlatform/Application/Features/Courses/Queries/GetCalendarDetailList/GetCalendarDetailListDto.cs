using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetCalendarDetailList;
public class GetCalendarDetailListDto:IDto
{
    public int Id { get; set; }
    public string SessionName { get; set; }
    public DateTime SessionStartDate { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
}
