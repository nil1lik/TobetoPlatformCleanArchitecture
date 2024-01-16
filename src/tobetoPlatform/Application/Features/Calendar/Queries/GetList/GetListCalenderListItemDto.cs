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
    public string SessionName { get; set; }
    public int InstructorId { get; set; }

}
